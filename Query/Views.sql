use WideWorldImporters;

CREATE VIEW CustomerView AS
	SELECT c.CustomerID,
		   c.CustomerName,
		   cc.CustomerCategoryName,
		   dm.DeliveryMethodName

	FROM Sales.Customers AS c LEFT JOIN 
		 Sales.CustomerCategories AS cc ON c.CustomerCategoryID = cc.CustomerCategoryID LEFT JOIN 
		 Application.DeliveryMethods AS dm ON c.DeliveryMethodID = dm.DeliveryMethodID

CREATE VIEW CustomerDetailsView AS
	SELECT c.CustomerID,
		   c.CustomerName,
		   cc.CustomerCategoryName,
		   bg.BuyingGroupName,
		   pp.FullName AS PrimaryContact, 
		   ap.FullName AS AlternateContact,
		   b.CustomerName AS BillToCustomer,
		   dm.DeliveryMethodName,
		   ct.CityName AS DeliveryCity,
		   c.DeliveryPostalCode,
		   c.PhoneNumber,
		   c.FaxNumber,
		   c.PaymentDays,
		   c.WebsiteURL,
		   CONCAT('Delivery: ', c.DeliveryAddressLine1, ', Postal: ', c.PostalAddressLine1) AS DeliveryPostal1,
		   CONCAT('Delivery: ', c.DeliveryAddressLine2, ', Postal: ', c.PostalAddressLine2) AS DeliveryPostal2,
		   c.DeliveryLocation.STAsText() AS DeliveryLocation

	FROM Sales.Customers AS c LEFT JOIN 
		 Sales.Customers AS b ON c.BillToCustomerID = b.CustomerID LEFT JOIN 
		 Sales.CustomerCategories AS cc ON c.CustomerCategoryID = cc.CustomerCategoryID LEFT JOIN 
		 Sales.BuyingGroups AS bg ON c.BuyingGroupID = bg.BuyingGroupID LEFT JOIN 
		 Application.People AS pp ON c.PrimaryContactPersonID = pp.PersonID LEFT JOIN 
		 Application.People AS ap ON c.AlternateContactPersonID = ap.PersonID LEFT JOIN 
		 Application.DeliveryMethods AS dm ON c.DeliveryMethodID = dm.DeliveryMethodID LEFT JOIN 
		 Application.Cities AS ct ON c.DeliveryCityID = ct.CityID

CREATE VIEW SupplierView AS
	SELECT s.SupplierID,
		   s.SupplierName,
		   sc.SupplierCategoryName,
		   dm.DeliveryMethodName

	FROM Purchasing.Suppliers AS s LEFT JOIN
		 Purchasing.SupplierCategories AS sc ON s.SupplierCategoryID = sc.SupplierCategoryID LEFT JOIN
		 Application.DeliveryMethods AS dm ON s.DeliveryMethodID = dm.DeliveryMethodID


CREATE VIEW SupplierDetailsView AS
	SELECT s.SupplierID,
		   s.SupplierReference, 
		   s.SupplierName,
		   sc.SupplierCategoryName,
		   pp.FullName AS PrimaryContact, 
		   ap.FullName AS AlternateContact,
		   dm.DeliveryMethodName,
		   ct.CityName AS DeliveryCity,
		   s.DeliveryPostalCode,
		   s.PhoneNumber,
		   s.FaxNumber,
		   s.WebsiteURL,
		   CONCAT('Delivery: ', s.DeliveryAddressLine1, ', Postal: ', s.PostalAddressLine1) AS DeliveryPostal1,
		   CONCAT('Delivery: ', s.DeliveryAddressLine2, ', Postal: ', s.PostalAddressLine2) AS DeliveryPostal2,
		   s.DeliveryLocation.STAsText() AS DeliveryLocation,
		   s.BankAccountName,
		   s.BankAccountNumber,
		   s.PaymentDays

	FROM Purchasing.Suppliers AS s LEFT JOIN
		 Purchasing.SupplierCategories AS sc ON s.SupplierCategoryID = sc.SupplierCategoryID LEFT JOIN
		 Application.People AS pp ON s.PrimaryContactPersonID = pp.PersonID LEFT JOIN 
		 Application.People AS ap ON s.AlternateContactPersonID = ap.PersonID LEFT JOIN
		 Application.DeliveryMethods AS dm ON s.DeliveryMethodID = dm.DeliveryMethodID LEFT JOIN 
		 Application.Cities AS ct ON s.DeliveryCityID = ct.CityID 