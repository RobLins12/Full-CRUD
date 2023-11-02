USE Northwind
GO
CREATE PROCEDURE GetCategorySalesReport
AS
    --Informações por Categoria
    SELECT 
        c.CategoryName AS Categoria, 
        COUNT(od.Quantity) AS QuantidadeVendida,
        ISNULL(SUM(od.UnitPrice * od.Quantity * (1 - od.Discount)), 0) as TotalDasVendas,
        TOPC.CustomerName AS MaiorComprador,
        TOPC.Country AS PaísComMaisCompras,
        TOPC.City AS CidadeComMaisCompras
    FROM 
        Categories c
    JOIN 
        Products p ON c.CategoryID = p.CategoryID
    JOIN 
        [Order Details] od ON p.ProductID = od.ProductID
    JOIN
        Orders o ON od.OrderID = o.OrderID
    JOIN
        Customers cu ON o.CustomerID = cu.CustomerID
    LEFT JOIN (
        SELECT 
            cu.CompanyName AS CustomerName,
            cu.Country,
            cu.City,
            p.CategoryID,
            ROW_NUMBER() OVER (PARTITION BY p.CategoryID ORDER BY COUNT(*) DESC) AS rn --Identificar o "maior comprador" dentro de cada categoria
        FROM 
            Customers cu
        JOIN 
            Orders o ON cu.CustomerID = o.CustomerID
        JOIN 
            [Order Details] od2 ON o.OrderID = od2.OrderID
        LEFT JOIN 
            Products p ON od2.ProductID = p.ProductID
        GROUP BY 
            cu.CompanyName, cu.Country, cu.City, p.CategoryID
    ) TOPC ON c.CategoryID = TOPC.CategoryID AND TOPC.rn = 1
    GROUP BY 
        c.CategoryName, c.CategoryID, TOPC.CustomerName, TOPC.Country, TOPC.City
    ORDER BY 
        TotalDasVendas DESC; --Ordenar pelo maior total de vendas
		
	RETURN;
GO
