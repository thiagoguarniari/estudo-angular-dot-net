PRINT N'Iniciando script para LeadProjectDatabase';
GO

USE [LeadProjectDatabase]

INSERT INTO Lead values 
('0f080c56-6263-480d-842a-9ba888094c8a', 'Bill', 'Smith', '20190104 10:34:09 AM', '123456789', 'billsmith@email.com', 
	'Yanderra 2574', 'Painters', 5577421, 'Need to paint 2 aluminum windows and a sliding glass door',
	62.00, 0, GETDATE(), 'Admin'),
('9a4ee37c-f360-4879-9871-5fe49853853f', 'Craig', 'Johnson', '20180104 11:50:17 AM', '987654321', 'craig.johnson@email.com', 
	'Woolooware 2230', 'Interior Painters', 5588872, 'internal walls 3 colours',
	49.00, 0, GETDATE(), 'Admin'),
('a6729bf7-6b88-4845-a45d-632dda9c30fc', 'Pete', 'Ferguson', '20180905 10:36:17 AM', '123654789', 'fergusonp@email.com', 
	'Carramar 6031', 'General Building Work', 5141895, 'Plaster exposed brick wall (see photos), square off 2 archways (see photos), and expand pantry (see photos).',
	26.00, 1, GETDATE(), 'Admin'),
('be2f03a2-696b-40da-9acb-d52a3719fa89', 'Chris Sanderson', 'Jordans', '20180830 11:14:17 AM', '321456987', 'chrissj@email.com', 
	'Quinns Rocks 6030', 'Home Renovations', 5121931, 'There is a two story building at the front of the main house that''s about 10x5 that would like to convert int self contained living area',
	32.00, 1, GETDATE(), 'Admin')
	
PRINT N'Finalizando script para LeadProjectDatabase';
GO