drop table if exists articles;

CREATE TABLE public.articles
(
	id uuid NOT NULL,
	description varchar null,
    likes int4 not null default 0,
	CONSTRAINT articles_pk PRIMARY KEY
	(id)
);

	insert into public.articles
		(id,description)
	values('2ae90450-9040-4f3d-900b-cd7565a1225c', 'Example description');