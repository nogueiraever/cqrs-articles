CREATE TABLE if not exists public.articles (
	id int8 NOT NULL GENERATED ALWAYS AS IDENTITY,
	description varchar null,
    likes int4 not null default 0,
	CONSTRAINT articles_pk PRIMARY KEY (id)
);