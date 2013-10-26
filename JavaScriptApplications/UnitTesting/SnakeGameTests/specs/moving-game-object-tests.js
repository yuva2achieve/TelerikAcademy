describe("MovingObject", function () {
	var position = {
		x: 25,
		y: 40
	};
	var size = 15,
		fcolor = "#000000",
		scolor = "#000000",
		speed = 5,
		direction = 0,
		piece;

	beforeEach(function () {
		piece = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);
	});

	describe("init", function () {
		it("Should set correct values", function () {
			expect(piece.position).toEqual(position);
			expect(piece.size).toBe(size);
			expect(piece.fcolor).toBe(fcolor);
			expect(piece.scolor).toBe(scolor);
			expect(piece.speed).toBe(speed);
			expect(piece.direction).toBe(direction);
		});
	});

	describe("move", function() {
	    it("when direction is 0, should decrease x", function() {
	      piece = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, 0);
	      piece.move();
	      expect(piece.position.x).toBe(position.x - speed);
	      expect(piece.position.y).toBe(position.y);
	    });

	    it("when direction is 1, should decrease y", function() {
	      piece = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, 1);
	      piece.move();
	      expect(piece.position.x).toBe(position.x);
	      expect(piece.position.y).toBe(position.y - speed);
	    });

	    it("when direction is 2, should increase x", function() {
	      piece = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, 2);
	      piece.move();
	      expect(piece.position.x).toBe(position.x + speed);
	      expect(piece.position.y).toBe(position.y);
	    });

	    it("when direction is 3, should increase y", function() {
	      piece = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, 3);
	      piece.move();
	      expect(piece.position.x).toBe(position.x);
	      expect(piece.position.y).toBe(position.y + speed);
	    });
  	});

	describe("changeDirection", function() {

    describe("when direction is 0", function() {
      beforeEach(function() {
        piece = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, 0);
      });

      it("new direction is 0, should set direction to 0", function() {
        piece.changeDirection(0);
        expect(piece.direction).toBe(0);
      });

      it("new direction is 1, should set direction to 1", function() {
        piece.changeDirection(1);
        expect(piece.direction).toBe(1);
      });

      it("new direction is 2, should set direction to 0", function() {
        piece.changeDirection(2);
        expect(piece.direction).toBe(0);
      });

      it("new direction is 3, should set direction to 3", function() {
        piece.changeDirection(3);
        expect(piece.direction).toBe(3);
      });
    });

    describe("when direction is 1", function() {
      beforeEach(function() {
        piece = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, 1);
      });

      it("new direction is 0, should set direction to 0", function() {
        piece.changeDirection(0);
        expect(piece.direction).toBe(0);
      });

      it("new direction is 1, should set direction to 1", function() {
        piece.changeDirection(1);
        expect(piece.direction).toBe(1);
      });

      it("new direction is 2, should set direction to 2", function() {
        piece.changeDirection(2);
        expect(piece.direction).toBe(2);
      });

      it("new direction is 3, should set direction to 1", function() {
        piece.changeDirection(3);
        expect(piece.direction).toBe(1);
      });
    });

    describe("when direction is 2", function() {
      beforeEach(function() {
        piece = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, 2);
      });

      it("new direction is 0, should set direction to 2", function() {
        piece.changeDirection(0);
        expect(piece.direction).toBe(2);
      });

      it("new direction is 1, should set direction to 1", function() {
        piece.changeDirection(1);
        expect(piece.direction).toBe(1);
      });

      it("new direction is 2, should set direction to 2", function() {
        piece.changeDirection(2);
        expect(piece.direction).toBe(2);
      });

      it("new direction is 3, should set direction to 3", function() {
        piece.changeDirection(3);
        expect(piece.direction).toBe(3);
      });
    });

    describe("when direction is 3", function() {    
      beforeEach(function() {
        piece = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, 3);
      });  

      it("new direction is 0, should set direction to 0", function() {
        piece.changeDirection(0);
        expect(piece.direction).toBe(0);
      });

      it("new direction is 1, should set direction to 3", function() {
        piece.changeDirection(1);
        expect(piece.direction).toBe(3);
      });

      it("new direction is 2, should set direction to 2", function() {
        piece.changeDirection(2);
        expect(piece.direction).toBe(2);
      });

      it("new direction is 3, should set direction to 3", function() {
        piece.changeDirection(3);
        expect(piece.direction).toBe(3);
      });
    });
  });
})