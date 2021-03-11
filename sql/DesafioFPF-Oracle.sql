IF DB_ID('desafiofpf') IS NULL BEGIN
	CREATE DATABASE desafiofpf
END
GO

USE desafiofpf

IF OBJECT_ID('RULE', 'R') IS NULL BEGIN
	CREATE TABLE RULE
	(
		ID NUMBER(*,0),
		NAME VARCHAR2(54 BYTE), 
		ACTIVE VARCHAR2(1 BYTE), 
		CREATED_AT TIMESTAMP (6), 
		MODIFIED_AT TIMESTAMP (6)
		CONSTRAINT PK_ID PRIMARY KEY (ID)
	)
END
GO


IF NOT EXISTS(SELECT 1 FROM RULE WHERE NAME = 'TESTE') BEGIN
	INSERT INTO RULE (ID, NAME, ACTIVE, CREATED_AT,MODIFIED_AT)
	VALUES (1,'TESTE', 'S', TIMESTAMP '2021-03-10 09:15:20',TIMESTAMP '2021-03-10 09:15:20')
END
GO
