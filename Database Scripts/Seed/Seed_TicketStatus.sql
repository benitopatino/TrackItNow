

use [TrackItNow]
go

Begin Transaction 

	Insert into TicketStatus values('New')
	Insert into TicketStatus values('In Progress')
	Insert into TicketStatus values('On Hold')
	Insert into TicketStatus values('Closed')

	if @@Error<>0
		rollback transaction
	else
		commit transaction

