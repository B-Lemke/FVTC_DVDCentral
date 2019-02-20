BEGIN
	INSERT INTO dbo.tblCustomer (Id, FirstName, LastName, [Address], City, [State], ZIP, Phone, UserId)
	VALUES (1, 'Anastasia', 'Montavon', '100 Grant St.', 'De Pere', 'WI', '54115',  '(920)555-6842', 1),
	(2, 'Broderick', 'Lemke', '2230 E. Shady Ave.', 'Neenah', 'WI', '54956',  '(920)555-5812', 2),
	(3, 'Guthree', 'McGunderson', '584 S. Poncho Blvd.', 'Mobile', 'AL', '36525',  '(251)555-8410', 3)
END