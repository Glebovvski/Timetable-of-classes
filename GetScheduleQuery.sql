select Day,ClassNumber,Number Room,PlacesAmount,Teachers.Name,Subjects.SubjectName from Schedules 
join Rooms on Schedules.Room_Id=Rooms.Id
join Teachers on Schedules.Teacher_Id=Teachers.Id
join Subjects on Schedules.Subject_Id=Subjects.Id
where Schedules.Group_Id=id