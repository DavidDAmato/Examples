describe('Given the Calculator', function() {
    var calc = new Calculator();
    var sum;

    it('Then it contains an add method', function() {
        expect(calc.add).toBeDefined();
    });

    describe('When I add two numbers', function() {

        it('Then the I get the correct answer', function() {
            sum = calc.add(1, 2);
            expect(sum).toBe(3);
        });
    });

    describe('When I add three numbers', function() {

        it('Then the I get the correct answer', function() {
            sum = calc.add(1, 2, 7);
            expect(sum).toBe(10);
        });
    });
});

/*

describe("Add", function () {
    it("Adds two integers", function () {
        var result = calculator.Add(5, 10);
        expect(result).toEqual(15);
    });
}).call(this);
*/