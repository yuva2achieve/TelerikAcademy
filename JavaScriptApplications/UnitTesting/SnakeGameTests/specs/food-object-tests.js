describe("Food", function () {
	var position = {
		x: 25,
		y: 40
	};
	var size = 15,
		foodFillColor = "#0000ff",
		foodStrokeColor = "#00ff00",
		foodPiece;

	beforeEach(function() {
		foodPiece = new snakeGame.Food(position,size);
	});

	describe("init", function() {
		it("Should initialize properly", function() {
			expect(foodPiece.position).toEqual(position);
			expect(foodPiece.size).toBe(size);
			expect(foodPiece.fcolor).toBe(foodFillColor);
			expect(foodPiece.scolor).toBe(foodStrokeColor);
		});
	});

	describe("changePosition", function() {
		it("Should change position properly", function() {
			var currentPosition = foodPiece.position;
			var expectedPosition = {
				x: 20,
				y: 35
			};

			foodPiece.changePosition(expectedPosition);
			expect(foodPiece.position).toNotEqual(currentPosition);
			expect(foodPiece.position).toEqual(expectedPosition);
		});
	});
});