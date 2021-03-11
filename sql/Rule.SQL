--------------------------------------------------------
--  Arquivo criado - Quinta-feira-Março-11-2021   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Table RULE
--------------------------------------------------------

  CREATE TABLE "SYSTEM"."RULE" 
   (	"ID" NUMBER(*,0), 
	"NAME" VARCHAR2(54), 
	"ACTIVE" VARCHAR2(1), 
	"CREATED_AT" TIMESTAMP (6), 
	"MODIFIED_AT" TIMESTAMP (6)
   ) ;
REM INSERTING into SYSTEM.RULE
SET DEFINE OFF;
Insert into SYSTEM.RULE (ID,NAME,ACTIVE,CREATED_AT,MODIFIED_AT) values ('1','Testes','S',to_timestamp('10/03/21 09:15:20,000000000','DD/MM/RR HH24:MI:SSXFF'),to_timestamp('10/03/21 09:15:20,000000000','DD/MM/RR HH24:MI:SSXFF'));
--------------------------------------------------------
--  DDL for Index PK_ID
--------------------------------------------------------

  CREATE UNIQUE INDEX "SYSTEM"."PK_ID" ON "SYSTEM"."RULE" ("ID") 
  ;
--------------------------------------------------------
--  Constraints for Table RULE
--------------------------------------------------------

  ALTER TABLE "SYSTEM"."RULE" ADD CONSTRAINT "PK_ID" PRIMARY KEY ("ID")
  USING INDEX  ENABLE;
