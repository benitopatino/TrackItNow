use [TrackItNow]
go

begin transaction 


	insert into TicketResolution values('Fixed')
	insert into TicketResolution values('Rejected')
	insert into TicketResolution values('Duplicate')

	if @@ERROR <> 0
		rollback transaction
	else 
		commit transaction

