ALTER TABLE Users 
DROP CONSTRAINT PK__Users__3214EC0769DCC959;

ALTER TABLE Users
ADD CONSTRAINT PK_IdUsername PRIMARY KEY (Id, Username);