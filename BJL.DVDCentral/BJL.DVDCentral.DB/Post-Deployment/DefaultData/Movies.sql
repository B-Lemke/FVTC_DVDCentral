BEGIN
	INSERT INTO dbo.tblMovie(Id, Title, [Description], ImagePath, Cost, RatingId, FormatId, DirectorId, Quantity)
	VALUES (1, 'Toy Story', 'A cowboy doll is profoundly threatened and jealous when a new spaceman figure supplants him as top toy.', 'Assests/Images/ToyStory.png', 19.99, 1, 1, 1, 15),
	(2, 'Bohemian Rhapsody', 'The story of the legendary rock band Queen and lead singer Freddie Mercury, leading up to their famous performance at Live Aid (1985)', 'Assests/Images/BohemianRhapsody.png', 49.99, 3, 3, 2, 20),
	(3, 'The Blair Witch Project', 'Three film students vanish after traveling into a Maryland forest to film a documentary on the local Blair Witch legend, leaving only their footage behind.', 'Assests/Images/BlairWitch.png', 5.99, 4, 2, 3, 2)
END