select Numero, T.IdClient, T.CodeType, E.Adresse, E.IdClient 
from Telephone T 
left outer join Client C on (C.Id=T.IdClient)
left outer join Email E on (C.Id=E.IdClient)
where C.Id=101
order by C.Id


select * from Client
where Id=101



