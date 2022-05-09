INSERT INTO `audb`.`role`
(`Name`,`Description`)VALUES('Receptionist','Receptionist');

INSERT INTO `audb`.`role`
(`Name`,`Description`)VALUES('Seller','Seller');

INSERT INTO `audb`.`role`
(`Name`,`Description`)VALUES('Owner','Owner');

INSERT INTO `audb`.`role`
(`Name`,`Description`)VALUES('SuperAdmin','SuperAdmin');

INSERT INTO `audb`.`user`
(
`UserName`,
`Password`,
`idOrganization`,
`isLocked`,
`FailureAttemptCount`,
`idRole`,
`CreatedDate`,
`CreatedBy`,
`isFirstTime`)
VALUES
(
'AuSystems',
'X6FlTAd9gAQlqeXcxjWR6Icr0syCJ0IXDkO4hUSKJXkQ2VHK',
1,
0,
0,
4,
CURDATE(),
1,
0);