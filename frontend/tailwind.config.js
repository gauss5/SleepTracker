/** @type {import('tailwindcss').Config} */
export default {
  content: [
    './index.html',
    './src/**/*.{vue,js,ts,jsx,tsx}'
  ],
  theme: {
    extend: {
      colors: {
        deep:    '#07080f',
        card:    '#0e1020',
        card2:   '#13152a',
        accent:  '#6c8dfa',
        'accent-soft': '#3d5ccc',
        teal:    '#4fd1c5',
        muted:   '#7b82a8',
      },
      fontFamily: {
        display: ['Syne', 'sans-serif'],
        body:    ['DM Sans', 'sans-serif'],
      }
    }
  },
  plugins: []
}
