//#region User
declare type User = {
  id: string;
  firstName: string;
  lastName: string;
  email: string;
  token?: string;
};

//#region Planner
declare type LessonPlan = {
  id: string;
  subject: Subject;
  planningNotes: string;
  startTime: Date;
  endTime: Date;
  numberOfPeriods: number;
  resources?: Resource[];
  summativeAssessments?: SummativeAssessment[];
  formativeAssessments?: FormativeAssessment[];
  lessonComments?: LessonComment[];
};

declare type WeekPlanner = {
  lessonPlans: LessonPlan[];
  events: SchoolEvent[];
  weekNumber: number;
  weekStart: Date;
};

declare type Break = {
  startTime: Date;
  endTime: Date;
  name: string;
  duty: string;
};

declare type SchoolEvent = {
  startTime: Date;
  endTime: Date;
  name: string;
  description: string;
  location: string;
};

//#region Curriculum
declare type Subject = {
  id: string;
  name: string;
  yearLevels: SubjectYearLevel[];
};

declare type SubjectYearLevel = {
  id: string;
  name: string;
  strands: Strand[];
};

declare type Strand = {
  id: string;
  name: string;
  substrands?: Substrand[];
  contentDescriptions?: ContentDescription[];
};

declare type Substrand = {
  id: string;
  name: string;
  contentDescriptions?: ContentDescription[];
};

declare type ContentDescription = {
  id: string;
  description: string;
  curriculumCode: string;
  elaborations: string[];
};

declare type Elaboration = {
  id: string;
  description: string;
};

declare type Resource = {
  id: string;
  description: string;
  link: string;
};

//#region Assessments
declare type Assessment = {
  id: string;
  description: string;
  student: Student;
  subjectName: string;
  dateConducted: Date;
} & (
  | {
      type: "summative";
      planningNotes?: string;
      dateScheduled: Date;
      grade: number | string;
    }
  | {
      type: "formative";
      comments: string;
    }
);
