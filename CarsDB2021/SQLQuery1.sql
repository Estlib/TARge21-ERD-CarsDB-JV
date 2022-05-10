Select CarInGarage.CarModelName, CarMark.CarMarkName from CarMark
inner join CarInGarage on CarInGarage.CarMarkId = CarMark.Id
where CarMark.CarMarkName like 'Tesla'

Select CarInGarage.CarModelName, CarMark.CarMarkName from CarMark
join CarInGarage on CarInGarage.CarMarkId = CarMark.Id