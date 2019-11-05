IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VM_finLedger]'))
EXEC dbo.sp_executesql 
@statement =  N'CREATE VIEW dbo.VIEW_FinLedger
AS
SELECT                   dbo.FinLedgers.CreateDate, dbo.FinLedgers.VKey, dbo.FinLedgers.GlCode, 
                         dbo.FinLedgers.Detail, dbo.FinLedgers.ChequeDate, dbo.FinLedgers.ClearingDate, 
                         dbo.FinLedgers.ChequeNo, dbo.FinLedgers.Debit, dbo.FinLedgers.Credit, 
                         dbo.CoaL1.L1Code, dbo.CoaL1.Title AS l1_Title, dbo.CoaL2.L2Code, 
                         dbo.CoaL2.Title AS l2_Title, dbo.CoaL3.L3Code, dbo.CoaL3.Title AS l3_Title, 
                         dbo.CoaL4.L4Code, dbo.CoaL4.Title AS L4_Title,dbo.CoaL5.L5Code, dbo.CoaL5.Title AS L5_Title
FROM  dbo.CoaL1 INNER JOIN
                         dbo.CoaL2 ON dbo.CoaL1.L1Code = dbo.CoaL2.L1Code INNER JOIN
                         dbo.CoaL3 ON dbo.CoaL2.L2Code = dbo.CoaL3.L2Code INNER JOIN
                         dbo.CoaL4 ON dbo.CoaL3.L3Code = dbo.CoaL4.L3Code INNER JOIN
                         dbo.CoaL5 ON dbo.CoaL4.L4Code = dbo.CoaL5.L4Code INNER JOIN
                         dbo.FinLedgers ON dbo.CoaL5.L5Code = dbo.FinLedgers.GlCode'