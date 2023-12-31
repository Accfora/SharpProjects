-- Запрос 1

select z1.Читатель 
from 
	(select [Читатель/E4].Код_читателя as Читатель, COUNT([Автор/E1].Код_автора) as Колво_Авторов
	from [Читатель/E4] inner join [Абонемент/Е3] on [Читатель/E4].Код_читателя = [Абонемент/Е3].Код_читателя 
						inner join [Книга/E2] on [Абонемент/Е3].Код_книги = [Книга/E2].Код_книги 
						inner join [Автор/E1] on [Книга/E2].Код_автора = [Автор/E1].Код_автора
	group by [Читатель/E4].Код_читателя) as z1
where Колво_Авторов = (select count(*) from [Автор/E1])

-- Запрос 2

select [Книга/E2].Код_автора, count([Книга/E2].Код_книги) as Количество_Книг
from [Книга/E2] inner join [Автор/E1] on [Книга/E2].Код_автора = [Автор/E1].Код_автора
where [Книга/E2].Код_книги not in
	(select distinct [Абонемент/Е3].Код_книги
	from [Абонемент/Е3])
group by [Книга/E2].Код_автора

-- Запрос 3

select [Книга/E2].Код_книги, [Книга/E2].Название
from
	(select top 3 [Абонемент/Е3].Код_книги, sum([Абонемент/Е3].Срок_возраста) as Задержка
	from [Абонемент/Е3]
	group by [Абонемент/Е3].Код_книги
	order by Задержка desc) as z3 inner join [Книга/E2] on z3.Код_книги = [Книга/E2].Код_книги

