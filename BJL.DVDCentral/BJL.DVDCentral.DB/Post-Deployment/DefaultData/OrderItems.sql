BEGIN
	INSERT INTO dbo.tblOrderItem(Id, OrderId, MovieId, Quantity)
	VALUES (1, 1, 1, 5),
	(2, 1, 2, 1),
	(3, 1, 3, 1),
	(4, 2, 2, 1),
	(5, 2, 3, 1),
	(6, 3, 1, 1),
	(7, 3, 2, 2)
END