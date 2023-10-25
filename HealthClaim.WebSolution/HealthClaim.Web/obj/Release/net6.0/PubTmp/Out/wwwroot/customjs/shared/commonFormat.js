//https://www.freecodecamp.org/news/how-to-format-number-as-currency-in-javascript-one-line-of-code/
var rupee = new Intl.NumberFormat('en-IN', {
    style: 'currency',
    currency: 'INR',
});
console.log('OpenFormat');


