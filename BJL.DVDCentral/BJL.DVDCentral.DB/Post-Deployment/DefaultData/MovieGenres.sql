BEGIN
	INSERT INTO dbo.tblMovieGenre(Id, MovieId, GenreId)
	VALUES (1, 1, 3),
	(2, 1, 1),
	(3, 2, 10),
	(4, 3, 4),
	(5, 3, 9)
END