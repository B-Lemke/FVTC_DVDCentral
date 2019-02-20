BEGIN
	INSERT INTO dbo.tblOrder(Id, CustomerId, OrderDate, PaymentReceipt, ShipDate)
	VALUES (1, 1, '2019-1-18', '2019-1-18', '2019-1-20'),
	(2, 3, '2018-11-1', '2018-11-1', '2018-11-10'),
	(3, 2, '2018-6-22', '2018-6-25', '2018-6-25')
END