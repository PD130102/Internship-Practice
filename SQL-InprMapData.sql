USE [Internship]
GO

INSERT INTO [dbo].[MapData_inpr]
           ([company_code]
           ,[company_name]
           ,[project_name]
           ,[inprogress_latitudes]
           ,[inprogress_longitudes])
     VALUES
           (1,'L&T Construction','ECC 1',23.7928,90.4082),
		   (1,'L&T Construction','ECC 2',28.6139,77.2091),
		   (1,'L&T Construction','ECC 3',19.8739,19.8739),
		   (2,'L&T Infotech','ELC 1',23.7928,90.4082),
		   (2,'L&T Infotech','ELC 2',28.6139,77.2091),
		   (2,'L&T Infotech','ELC 3',19.8739,19.8739)
GO


