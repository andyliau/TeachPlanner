﻿using Domain.Common.Enums;
using Domain.SubjectAggregates;
using Application.Common.Extensions;

namespace Infrastructure.Curriculum;

internal class MathematicsParser
{
    internal Subject ParseMathematics(string[] contentArr, string subjectName, int index)
    {
        var subject = Subject.Create(subjectName, new List<YearLevel>());

        try
        {
            while (index < contentArr.Length)
            {
                YearLevel yearLevel = ParseYearLevel(contentArr, ref index);
                subject.AddYearLevel(yearLevel);
                // "Australian Curriculum:" appears after all curriculum content for each subject.
                if (contentArr[index].StartsWith("Australian Curriculum:"))
                {
                    break;
                }
            }
        }
        catch (Exception ex) { Console.WriteLine("Index: " + index); }
        return subject;
    }

    private YearLevel ParseYearLevel(string[] contentArr, ref int index)
    {
        YearLevelValue yearLevelValue = contentArr[index] == "Foundation" ? YearLevelValue.Foundation : (YearLevelValue)Enum.Parse(typeof(YearLevelValue), contentArr[index].Replace(" ", ""));

        index += 2;
        string description = "";

        do
        {
            if (contentArr[index].StartsWith("*"))
            {
                description += contentArr[index] + "\n";
            }
            else
            {
                description += contentArr[index] + "\n\n";
            }

            index++;
        }
        while (!contentArr[index].StartsWith("Achievement standard"));

        index++;

        // iterate over next x lines to capture the entire achievement standard
        string achievementStandard = "";
        do
        {
            achievementStandard += contentArr[index] + "\n\n";
            index++;
        } while (!contentArr[index].StartsWith("Strand"));

        var yearLevel = YearLevel.Create(yearLevelValue, new List<Strand>(), description, achievementStandard);

        // continue parsing document until the next line doesn't begin with strand.

        while (contentArr[index].StartsWith("Strand"))
        {
            var strand = GetStrand(contentArr, ref index);

            yearLevel.AddStrand(strand);

        }

        return yearLevel;
    }

    private Strand GetStrand(string[] contentArr, ref int index)
    {
        // remove "Strand:" from name
        string name = contentArr[index].Substring(8);
        index += 2;

        // we know there won't be an argument error here
        var strand = Strand.Create(name, substrands: new List<Substrand>()).AsT0;

        while (contentArr[index].StartsWith("Sub-strand"))
        {
            var substrand = GetSubstrand(contentArr, ref index);
            strand.AddSubstrand(substrand);
        }

        return strand;
    }

    private Substrand GetSubstrand(string[] contentArr, ref int index)
    {
        // remove "Sub-strand:" from name
        var name = contentArr[index].Substring(12);
        var substrand = Substrand.Create(name, new List<ContentDescriptor>());

        if (contentArr[index + 1] == "Content descriptions")
        {
            index += 5;
        }
        else
        {
            index++;
        }

        // each time GetContentDescriptions returns, check whether the next line starts with AC9 (instead of another header) and repeat if so.
        while (contentArr[index + 1].StartsWith("AC9"))
        {
            var contentDescriptor = GetContentDescriptors(contentArr, ref index);

            substrand.AddContentDescriptor(contentDescriptor);
        }

        return substrand;
    }

    private ContentDescriptor GetContentDescriptors(string[] contentArr, ref int index)
    {
        var description = contentArr[index].WithFirstLetterUpper();
        index++;

        var curriculumCode = contentArr[index];
        index++;

        var contentDescriptor = ContentDescriptor.Create(description, curriculumCode, new List<Elaboration>());

        while (contentArr[index].StartsWith("*"))
        {
            var content = contentArr[index].Substring(2);
            var elaboration = Elaboration.Create(content);

            contentDescriptor.AddElaboration(elaboration);
            index++;
        }

        return contentDescriptor;
    }
    // Maths is dealt with differently as there are no substrands in the curriculum
    /*
     * This function will create a placeholder substrand to keep the object model consistent 
     * Iterate over the content descriptions and add them the dummy substrand
     * return the completed strand
     */
    /*    private Strand GetMathsStrand(string[] contentArr, ref int index)
        {
            Strand strand = new();
            strand.Name = contentArr[index].Substring(8);

            Substrand substrand = new()
            {
                Strand = strand
            };

            index += 6;

            while (contentArr[index + 1].StartsWith("AC9"))
            {
                ContentDescription contentDescription = GetContentDescriptors(contentArr, ref index);
                contentDescription.Substrand = substrand;
                substrand.ContentDescriptions.Add(contentDescription);
            }
            strand.Substrands.Add(substrand);
            return strand;
        }
    */
}