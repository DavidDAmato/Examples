// return true if the number is either all numbers, 1234, or parsable as a int, "123455"
function isNumber(n) {
    return /^-?[\d.]+(?:e-?\d+)?$/.test(n); 
} 