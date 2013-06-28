/// <reference path="QUnit/qunit-1.11.0.js" />

module("MovingGameObject.init");

test("Testing constructor correct initialization", function () {
    var position = { x: 5, y: 7 },
        size = 5,
        fcolor = "#000000",
        scolor = "#000000",
        speed = 42,
        direction = 0;

    var movingObject = new snakeGame.MovingGameObject(
      position, size, fcolor, scolor, speed, direction);

    equal(movingObject.position, position, "position test");
    equal(movingObject.size, size, "size test");
    equal(movingObject.fcolor, fcolor, "fill color test");
    equal(movingObject.scolor, scolor, "stroke color test");
    equal(movingObject.speed, speed, "speed test");
    equal(movingObject.direction, direction, "direction test");
});

(function () {

    // initialize an object to use in all the tests
    QUnit.testStart(function () {
        var position = { x: 0, y: 0 }, size = 1, fcolor = "#000000", scolor = "#000000", speed = 3, direction = 0;
        movingObj = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);
    });

    var movingObj;

    module("MovingGameObject.changeDirection")
    test("Change to 1 (succeed expected)", function () {
        var movingObject = movingObj;
        movingObject.direction = 0;
        var newDirection = 1;
        movingObject.changeDirection(newDirection);
        equal(movingObject.direction, newDirection);
    });

    test("Change to 3 (succeed expected)", function () {
        var movingObject = movingObj;
        movingObject.direction = 0;
        var newDirection = 3;
        movingObject.changeDirection(newDirection);
        equal(movingObject.direction, newDirection);
    });

    test("Change to 0 (no change expected)", function () {
        var movingObject = movingObj;
        movingObject.direction = 0;
        var oldDirection = movingObject.direction;
        var newDirection = 0;
        movingObject.changeDirection(newDirection);
        equal(movingObject.direction, oldDirection);
    });

    test("Change to 2 (no change expected)", function () {
        var movingObject = movingObj;
        movingObject.direction = 0;
        var oldDirection = movingObject.direction;
        var newDirection = 2;
        movingObject.changeDirection(newDirection);
        equal(movingObject.direction, oldDirection);
    });

    test("Change to 0 (succeed expected)", function () {
        var movingObject = movingObj;
        movingObject.direction = 1;
        var newDirection = 0;
        movingObject.changeDirection(newDirection);
        equal(movingObject.direction, newDirection);
    });

    test("Change to 2 (succeed expected)", function () {
        var movingObject = movingObj;
        movingObject.direction = 1;
        var newDirection = 2;
        movingObject.changeDirection(newDirection);
        equal(movingObject.direction, newDirection);
    });

    test("Change to 3 (no change expected)", function () {
        var movingObject = movingObj;
        movingObject.direction = 1;
        var oldDirection = movingObject.direction;
        var newDirection = 3;
        movingObject.changeDirection(newDirection);
        equal(movingObject.direction, oldDirection);
    });

    test("Change to 1 (no change expected)", function () {
        var movingObject = movingObj;
        movingObject.direction = 1;
        var oldDirection = movingObject.direction;
        var newDirection = 1;
        movingObject.changeDirection(newDirection);
        equal(movingObject.direction, oldDirection);
    });

    test("Change to 1 (succeed expected)", function () {
        var movingObject = movingObj;
        movingObject.direction = 2;
        var newDirection = 1;
        movingObject.changeDirection(newDirection);
        equal(movingObject.direction, newDirection);
    });

    test("Change to 3 (succeed expected)", function () {
        var movingObject = movingObj;
        movingObject.direction = 2;
        var newDirection = 3;
        movingObject.changeDirection(newDirection);
        equal(movingObject.direction, newDirection);
    });

    test("Change to 0 (no change expected)", function () {
        var movingObject = movingObj;
        movingObject.direction = 2;
        var oldDirection = movingObject.direction;
        var newDirection = 0;
        movingObject.changeDirection(newDirection);
        equal(movingObject.direction, oldDirection);
    });

    test("Change to 2 (no change expected)", function () {
        var movingObject = movingObj;
        movingObject.direction = 2;
        var oldDirection = movingObject.direction;
        var newDirection = 2;
        movingObject.changeDirection(newDirection);
        equal(movingObject.direction, oldDirection);
    });

    test("Change to 0 (succeed expected)", function () {
        var movingObject = movingObj;
        movingObject.direction = 3;
        var newDirection = 0;
        movingObject.changeDirection(newDirection);
        equal(movingObject.direction, newDirection);
    });

    test("Change to 2 (succeed expected)", function () {
        var movingObject = movingObj;
        movingObject.direction = 3;
        var newDirection = 2;
        movingObject.changeDirection(newDirection);
        equal(movingObject.direction, newDirection);
    });

    test("Change to 1 (no change expected)", function () {
        var movingObject = movingObj;
        movingObject.direction = 3;
        var oldDirection = movingObject.direction;
        var newDirection = 1;
        movingObject.changeDirection(newDirection);
        equal(movingObject.direction, oldDirection);
    });

    test("Change to 3 (no change expected)", function () {
        var movingObject = movingObj;
        movingObject.direction = 3;
        var oldDirection = movingObject.direction;
        var newDirection = 3;
        movingObject.changeDirection(newDirection);
        equal(movingObject.direction, oldDirection);
    });

    // Clear previously registered callbacks
    QUnit.testStart(function () { });
}());