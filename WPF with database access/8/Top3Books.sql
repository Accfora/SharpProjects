select ��������, count(*) as ������������
from [���������/�3] inner join [�����/E2] on [���������/�3].���_����� = [�����/E2].���_�����
group by ��������, [�����/E2].���_�����
having count(*) >= (select min (help.�����)
				    from (select top 3 ���_�����, count(*) as �����
					   	  from [���������/�3]
						  group by ���_�����
						  order by ����� desc) as help)
order by ������������ desc