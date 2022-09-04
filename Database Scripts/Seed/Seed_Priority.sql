
use [TrackItNow]
go

Begin Transaction
	Insert into Priority values('Low');
	Insert into Priority values('Medium');
	Insert into Priority values ('High');

	if @@Error <> 0
		rollback transaction
	else 
		commit transaction