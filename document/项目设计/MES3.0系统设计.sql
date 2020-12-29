CREATE TABLE MFG_BarcodePokayoke (
 ID INT NOT NULL,
 MainPartNo NVARCHAR(20),
 MainPartVersion NVARCHAR(20),
 PokayokeCode NVARCHAR(20),
 Enabled BIT(0)
);

ALTER TABLE MFG_BarcodePokayoke ADD CONSTRAINT PK_MFG_BarcodePokayoke PRIMARY KEY (ID);


