type EventCalendarEntryProps = {
  schoolEvent: SchoolEvent;
  columnIndex: number;
  rowIndex: number;
};

export default function EventCalendarEntry({ schoolEvent, columnIndex, rowIndex }: EventCalendarEntryProps) {
  return (
    <div
      className={`col-start-[${columnIndex}] col-span-1 row-[span_${rowIndex}_/_span_${
        rowIndex + schoolEvent.numberOfPeriods
      }] row-start-[${rowIndex}] row-end-[${rowIndex + schoolEvent.numberOfPeriods}] border-r-2 border-b-2 border-darkGreen`}>
      <p>{schoolEvent.name}</p>
      <p>{schoolEvent.location}</p>
    </div>
  );
}
