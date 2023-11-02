CREATE TRIGGER PreventZeroStockPurchase
ON [Order Details]
FOR INSERT
AS
BEGIN
    -- Verifica se h� produtos com estoque zero na compra
    IF EXISTS (SELECT  1 FROM inserted i JOIN Products p ON i.ProductID = p.ProductID WHERE p.UnitsInStock = 0)
    BEGIN
        PRINT 'Compra n�o pode ser realizada. Produto com estoque zero.'
        ROLLBACK TRANSACTION;
    END
END;

