use WideWorldImporters

CREATE PROCEDURE GetFilteredCustomers
    @CustomerName NVARCHAR(100) = NULL,
    @CustomerCategoryName NVARCHAR(100) = NULL,
    @DeliveryMethodName NVARCHAR(100) = NULL
AS
BEGIN
    SELECT 
        CustomerID,
        CustomerName,
        CustomerCategoryName,
        DeliveryMethodName
    FROM 
        CustomerDetailsView
    WHERE 
        (@CustomerName IS NULL OR CustomerName LIKE '%' + @CustomerName + '%') AND
        (@CustomerCategoryName IS NULL OR CustomerCategoryName LIKE '%' + @CustomerCategoryName + '%') AND
        (@DeliveryMethodName IS NULL OR DeliveryMethodName LIKE '%' + @DeliveryMethodName + '%')
    ORDER BY 
        CustomerName ASC;  
END;

CREATE PROCEDURE GetCustomerDetails
    @CustomerID INT
AS
BEGIN
    SELECT 
        CustomerID,
        CustomerName,
        CustomerCategoryName,
        BuyingGroupName,
        PrimaryContact,
        AlternateContact,
        BillToCustomer,
        DeliveryMethodName,
        DeliveryCity,
        DeliveryPostalCode,
        PhoneNumber,
        FaxNumber,
        PaymentDays,
        WebsiteURL,
        DeliveryPostal1,
        DeliveryPostal2,
        DeliveryLocation
    FROM 
        CustomerDetailsView
    WHERE 
        CustomerID = @CustomerID;
END;

CREATE PROCEDURE GetFilteredSuppliers
    @SupplierName NVARCHAR(100) = NULL,
    @SupplierCategoryName NVARCHAR(100) = NULL,
    @DeliveryMethodName NVARCHAR(100) = NULL
AS
BEGIN
    SELECT 
        SupplierID,
        SupplierName,
        SupplierCategoryName,
        DeliveryMethodName
    FROM 
        SupplierView
    WHERE 
        (@SupplierName IS NULL OR SupplierName LIKE '%' + @SupplierName + '%') AND
        (@SupplierCategoryName IS NULL OR SupplierCategoryName LIKE '%' + @SupplierCategoryName + '%') AND
        (@DeliveryMethodName IS NULL OR DeliveryMethodName LIKE '%' + @DeliveryMethodName + '%')
    ORDER BY 
        SupplierName ASC;
END;

CREATE PROCEDURE GetSupplierDetails
    @SupplierID INT
AS
BEGIN
    SELECT 
        SupplierID,
        SupplierReference,
        SupplierName,
        SupplierCategoryName,
        PrimaryContact,
        AlternateContact,
        DeliveryMethodName,
        DeliveryCity,
        DeliveryPostalCode,
        PhoneNumber,
        FaxNumber,
        WebsiteURL,
        DeliveryPostal1,
        DeliveryPostal2,
        DeliveryLocation,
        BankAccountName,
        BankAccountNumber,
        PaymentDays
    FROM 
        SupplierDetailsView
    WHERE 
        SupplierID = @SupplierID;
END;