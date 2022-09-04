use [TrackItNow]
go

Begin Transaction

	Insert into TicketType values('Bug Fix')
	Insert into TicketType values('Feature')
	Insert into TicketType values('Enhancement')

	if @@ERROR <> 0
		rollback transaction
	else
		commit transaction
