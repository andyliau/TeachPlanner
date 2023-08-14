/** @type {import('tailwindcss').Config} */
export default {
  content: ["./index.html", "./src/**/*.{js,jsx,ts,tsx}"],
  theme: {
    extend: {
      colors: {
        primary: "#EEE6DE",
        sage: "#90AEB2",
        darkGreen: "#37514D",
        peach: "#DD8E75",
        ceramic: "#B6594C",
      },
      height: {
        screen: "100dvh",
      },
      minHeight: {
        screen: "100dvh",
      },
    },
  },
  safelist: [
    "col-start-2",
    "col-start-3",
    "col-start-4",
    "col-start-5",
    "col-start-6",
    "col-start-7",
    "col-start-8",
    "row-start-1",
    "row-start-2",
    "row-start-3",
    "row-start-4",
    "row-start-5",
    "row-start-6",
    "row-start-7",
    "row-start-8",
    "row-start-9",
    "row-start-10",
    "row-end-1",
    "row-end-2",
    "row-end-3",
    "row-end-4",
    "row-end-5",
    "row-end-6",
    "row-end-7",
    "row-end-8",
    "row-end-9",
    "row-end-10",
    "row-end-11",
    "row-end-12",
    "row-span-1",
    "row-span-2",
    {
      pattern: /grid-rows-[^\s]+/
    }],
  plugins: ["prettier-plugin-tailwindcss"],
};
