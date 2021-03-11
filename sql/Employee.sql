--------------------------------------------------------
--  Arquivo criado - Quinta-feira-Março-11-2021   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Table EMPLOYEE
--------------------------------------------------------

  CREATE TABLE "SYSTEM"."EMPLOYEE" 
   (	"ID" NUMBER(*,0), 
	"ID_RULE" NUMBER(*,0), 
	"NAME" VARCHAR2(104), 
	"SALARY" NUMBER(10,2), 
	"GENDER" VARCHAR2(1), 
	"ACTIVE" VARCHAR2(1), 
	"CREATED_AT" TIMESTAMP (6), 
	"MODIFIED_AT" TIMESTAMP (6)
   ) ;
REM INSERTING into SYSTEM.EMPLOYEE
SET DEFINE OFF;
Insert into SYSTEM.EMPLOYEE (ID,ID_RULE,NAME,SALARY,GENDER,ACTIVE,CREATED_AT,MODIFIED_AT) values ('1','1','sdsdfsdfsdfsdfsd','45','m','s',to_timestamp('11/03/21 12:21:00,000000000','DD/MM/RR HH24:MI:SSXFF'),to_timestamp('11/03/21 12:21:00,000000000','DD/MM/RR HH24:MI:SSXFF'));
--------------------------------------------------------
--  DDL for Index EMPLOYEE_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "SYSTEM"."EMPLOYEE_PK" ON "SYSTEM"."EMPLOYEE" ("ID") 
  ;
--------------------------------------------------------
--  Constraints for Table EMPLOYEE
--------------------------------------------------------

  ALTER TABLE "SYSTEM"."EMPLOYEE" MODIFY ("ID" NOT NULL ENABLE);
  ALTER TABLE "SYSTEM"."EMPLOYEE" MODIFY ("ID_RULE" NOT NULL ENABLE);
  ALTER TABLE "SYSTEM"."EMPLOYEE" MODIFY ("NAME" NOT NULL ENABLE);
  ALTER TABLE "SYSTEM"."EMPLOYEE" MODIFY ("SALARY" NOT NULL ENABLE);
  ALTER TABLE "SYSTEM"."EMPLOYEE" MODIFY ("GENDER" NOT NULL ENABLE);
  ALTER TABLE "SYSTEM"."EMPLOYEE" MODIFY ("ACTIVE" NOT NULL ENABLE);
  ALTER TABLE "SYSTEM"."EMPLOYEE" MODIFY ("CREATED_AT" NOT NULL ENABLE);
  ALTER TABLE "SYSTEM"."EMPLOYEE" MODIFY ("MODIFIED_AT" NOT NULL ENABLE);
  ALTER TABLE "SYSTEM"."EMPLOYEE" ADD CONSTRAINT "EMPLOYEE_PK" PRIMARY KEY ("ID")
  USING INDEX  ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table EMPLOYEE
--------------------------------------------------------

  ALTER TABLE "SYSTEM"."EMPLOYEE" ADD CONSTRAINT "RULE_FK" FOREIGN KEY ("ID_RULE")
	  REFERENCES "SYSTEM"."RULE" ("ID") ENABLE;
