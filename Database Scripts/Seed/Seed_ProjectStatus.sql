use [TrackItNow]
go

Begin Transaction
	Insert into ProjectStatus values('Open');
	Insert into ProjectStatus values('On Hold');
	insert into ProjectStatus values('Closed');

	if @@Error <> 0
		rollback transaction
	else
		commit transaction 
