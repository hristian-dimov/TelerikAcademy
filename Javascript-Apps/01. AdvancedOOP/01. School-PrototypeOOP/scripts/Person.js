var Person = {
    init: function (firstName, lastName, age) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    },

    introduce: function () {
        return "Name: " + this.firstName + " " + this.lastName + ", Age: " + this.age;
    }
};

var Student = Person.extend({
    init: function (firstName, lastName, age, grade) {
        Person.init.apply(this, arguments);
        this.grade = grade;
    },

    introduce: function () {
        return Person.introduce.apply(this) + ", Grade: " + this.grade;
    }
});

var Teacher = Person.extend({
    init: function (firstName, lastName, age, speciality) {
        Person.init.apply(this, arguments);
        this.speciality = speciality;
    },

    introduce: function () {
        return Person.introduce.apply(this) + ", Specialty: " + this.speciality;
    }
});