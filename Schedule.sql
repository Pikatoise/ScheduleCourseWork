--
-- PostgreSQL database dump
--

-- Dumped from database version 15.2
-- Dumped by pg_dump version 15.2

-- Started on 2023-05-18 15:12:42

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 217 (class 1259 OID 16418)
-- Name: cabinets; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.cabinets (
    id integer NOT NULL,
    name text NOT NULL,
    comment text
);


ALTER TABLE public.cabinets OWNER TO postgres;

--
-- TOC entry 216 (class 1259 OID 16417)
-- Name: cabinets_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.cabinets_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.cabinets_id_seq OWNER TO postgres;

--
-- TOC entry 3414 (class 0 OID 0)
-- Dependencies: 216
-- Name: cabinets_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.cabinets_id_seq OWNED BY public.cabinets.id;


--
-- TOC entry 229 (class 1259 OID 16510)
-- Name: schedulechanged; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.schedulechanged (
    id integer NOT NULL,
    teacher integer NOT NULL,
    cabinet integer NOT NULL,
    schedulecurrent integer NOT NULL,
    studygroup integer NOT NULL,
    sequencenumber integer NOT NULL,
    subject integer NOT NULL,
    division text NOT NULL,
    isremote boolean NOT NULL
);


ALTER TABLE public.schedulechanged OWNER TO postgres;

--
-- TOC entry 228 (class 1259 OID 16509)
-- Name: schedulechanged_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.schedulechanged_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.schedulechanged_id_seq OWNER TO postgres;

--
-- TOC entry 3415 (class 0 OID 0)
-- Dependencies: 228
-- Name: schedulechanged_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.schedulechanged_id_seq OWNED BY public.schedulechanged.id;


--
-- TOC entry 227 (class 1259 OID 16496)
-- Name: schedulecurrents; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.schedulecurrents (
    id integer NOT NULL,
    currentdate date NOT NULL,
    weekday integer NOT NULL,
    daytype text NOT NULL
);


ALTER TABLE public.schedulecurrents OWNER TO postgres;

--
-- TOC entry 226 (class 1259 OID 16495)
-- Name: schedulecurrents_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.schedulecurrents_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.schedulecurrents_id_seq OWNER TO postgres;

--
-- TOC entry 3416 (class 0 OID 0)
-- Dependencies: 226
-- Name: schedulecurrents_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.schedulecurrents_id_seq OWNED BY public.schedulecurrents.id;


--
-- TOC entry 225 (class 1259 OID 16462)
-- Name: schedulestandart; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.schedulestandart (
    id integer NOT NULL,
    studygroup integer NOT NULL,
    sequencenumber integer NOT NULL,
    subject integer NOT NULL,
    teacher integer NOT NULL,
    cabinet integer NOT NULL,
    division text NOT NULL,
    weekday integer NOT NULL,
    daytype text NOT NULL,
    isremote boolean NOT NULL
);


ALTER TABLE public.schedulestandart OWNER TO postgres;

--
-- TOC entry 224 (class 1259 OID 16461)
-- Name: schedulestandart_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.schedulestandart_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.schedulestandart_id_seq OWNER TO postgres;

--
-- TOC entry 3417 (class 0 OID 0)
-- Dependencies: 224
-- Name: schedulestandart_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.schedulestandart_id_seq OWNED BY public.schedulestandart.id;


--
-- TOC entry 219 (class 1259 OID 16429)
-- Name: studygroups; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.studygroups (
    id integer NOT NULL,
    name text NOT NULL,
    comment text
);


ALTER TABLE public.studygroups OWNER TO postgres;

--
-- TOC entry 218 (class 1259 OID 16428)
-- Name: studygroups_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.studygroups_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.studygroups_id_seq OWNER TO postgres;

--
-- TOC entry 3418 (class 0 OID 0)
-- Dependencies: 218
-- Name: studygroups_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.studygroups_id_seq OWNED BY public.studygroups.id;


--
-- TOC entry 223 (class 1259 OID 16451)
-- Name: subjects; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.subjects (
    id integer NOT NULL,
    name text NOT NULL
);


ALTER TABLE public.subjects OWNER TO postgres;

--
-- TOC entry 222 (class 1259 OID 16450)
-- Name: subjects_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.subjects_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.subjects_id_seq OWNER TO postgres;

--
-- TOC entry 3419 (class 0 OID 0)
-- Dependencies: 222
-- Name: subjects_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.subjects_id_seq OWNED BY public.subjects.id;


--
-- TOC entry 215 (class 1259 OID 16409)
-- Name: teachers; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.teachers (
    id integer NOT NULL,
    firstname text NOT NULL,
    lastname text NOT NULL,
    surname text
);


ALTER TABLE public.teachers OWNER TO postgres;

--
-- TOC entry 214 (class 1259 OID 16408)
-- Name: teachers_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.teachers_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.teachers_id_seq OWNER TO postgres;

--
-- TOC entry 3420 (class 0 OID 0)
-- Dependencies: 214
-- Name: teachers_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.teachers_id_seq OWNED BY public.teachers.id;


--
-- TOC entry 221 (class 1259 OID 16440)
-- Name: weekdays; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.weekdays (
    id integer NOT NULL,
    name text NOT NULL
);


ALTER TABLE public.weekdays OWNER TO postgres;

--
-- TOC entry 220 (class 1259 OID 16439)
-- Name: weekdays_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.weekdays_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.weekdays_id_seq OWNER TO postgres;

--
-- TOC entry 3421 (class 0 OID 0)
-- Dependencies: 220
-- Name: weekdays_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.weekdays_id_seq OWNED BY public.weekdays.id;


--
-- TOC entry 3209 (class 2604 OID 16536)
-- Name: cabinets id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.cabinets ALTER COLUMN id SET DEFAULT nextval('public.cabinets_id_seq'::regclass);


--
-- TOC entry 3215 (class 2604 OID 16537)
-- Name: schedulechanged id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.schedulechanged ALTER COLUMN id SET DEFAULT nextval('public.schedulechanged_id_seq'::regclass);


--
-- TOC entry 3214 (class 2604 OID 16538)
-- Name: schedulecurrents id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.schedulecurrents ALTER COLUMN id SET DEFAULT nextval('public.schedulecurrents_id_seq'::regclass);


--
-- TOC entry 3213 (class 2604 OID 16539)
-- Name: schedulestandart id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.schedulestandart ALTER COLUMN id SET DEFAULT nextval('public.schedulestandart_id_seq'::regclass);


--
-- TOC entry 3210 (class 2604 OID 16540)
-- Name: studygroups id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.studygroups ALTER COLUMN id SET DEFAULT nextval('public.studygroups_id_seq'::regclass);


--
-- TOC entry 3212 (class 2604 OID 16541)
-- Name: subjects id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.subjects ALTER COLUMN id SET DEFAULT nextval('public.subjects_id_seq'::regclass);


--
-- TOC entry 3208 (class 2604 OID 16542)
-- Name: teachers id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.teachers ALTER COLUMN id SET DEFAULT nextval('public.teachers_id_seq'::regclass);


--
-- TOC entry 3211 (class 2604 OID 16543)
-- Name: weekdays id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.weekdays ALTER COLUMN id SET DEFAULT nextval('public.weekdays_id_seq'::regclass);


--
-- TOC entry 3396 (class 0 OID 16418)
-- Dependencies: 217
-- Data for Name: cabinets; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.cabinets (id, name, comment) VALUES (1, '39', 'Доска');
INSERT INTO public.cabinets (id, name, comment) VALUES (4, '32', 'Старое оборудование');


--
-- TOC entry 3408 (class 0 OID 16510)
-- Dependencies: 229
-- Data for Name: schedulechanged; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.schedulechanged (id, teacher, cabinet, schedulecurrent, studygroup, sequencenumber, subject, division, isremote) VALUES (1, 1, 1, 1, 1, 1, 1, 'Общая', false);


--
-- TOC entry 3406 (class 0 OID 16496)
-- Dependencies: 227
-- Data for Name: schedulecurrents; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.schedulecurrents (id, currentdate, weekday, daytype) VALUES (3, '2023-05-13', 2, 'Числитель');
INSERT INTO public.schedulecurrents (id, currentdate, weekday, daytype) VALUES (1, '2023-05-03', 1, 'Знаменатель');


--
-- TOC entry 3404 (class 0 OID 16462)
-- Dependencies: 225
-- Data for Name: schedulestandart; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.schedulestandart (id, studygroup, sequencenumber, subject, teacher, cabinet, division, weekday, daytype, isremote) VALUES (2, 1, 1, 1, 1, 1, 'Общая', 1, 'Числитель', true);
INSERT INTO public.schedulestandart (id, studygroup, sequencenumber, subject, teacher, cabinet, division, weekday, daytype, isremote) VALUES (6, 2, 3, 1, 1, 1, 'Первая', 1, 'Числитель', false);
INSERT INTO public.schedulestandart (id, studygroup, sequencenumber, subject, teacher, cabinet, division, weekday, daytype, isremote) VALUES (9, 1, 3, 2, 1, 1, 'Первая', 1, 'Числитель', false);


--
-- TOC entry 3398 (class 0 OID 16429)
-- Dependencies: 219
-- Data for Name: studygroups; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.studygroups (id, name, comment) VALUES (1, 'ИСП-6,7', NULL);
INSERT INTO public.studygroups (id, name, comment) VALUES (2, 'ПБ-19', NULL);


--
-- TOC entry 3402 (class 0 OID 16451)
-- Dependencies: 223
-- Data for Name: subjects; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.subjects (id, name) VALUES (1, 'МДК 11.01');
INSERT INTO public.subjects (id, name) VALUES (2, 'Английский язык');


--
-- TOC entry 3394 (class 0 OID 16409)
-- Dependencies: 215
-- Data for Name: teachers; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.teachers (id, firstname, lastname, surname) VALUES (1, 'Игорь', 'Финк', 'Валерьевич');


--
-- TOC entry 3400 (class 0 OID 16440)
-- Dependencies: 221
-- Data for Name: weekdays; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.weekdays (id, name) VALUES (1, 'Понедельник');
INSERT INTO public.weekdays (id, name) VALUES (2, 'Вторник');
INSERT INTO public.weekdays (id, name) VALUES (3, 'Среда');
INSERT INTO public.weekdays (id, name) VALUES (4, 'Четверг');
INSERT INTO public.weekdays (id, name) VALUES (5, 'Пятница');
INSERT INTO public.weekdays (id, name) VALUES (6, 'Суббота');


--
-- TOC entry 3422 (class 0 OID 0)
-- Dependencies: 216
-- Name: cabinets_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.cabinets_id_seq', 4, true);


--
-- TOC entry 3423 (class 0 OID 0)
-- Dependencies: 228
-- Name: schedulechanged_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.schedulechanged_id_seq', 2, true);


--
-- TOC entry 3424 (class 0 OID 0)
-- Dependencies: 226
-- Name: schedulecurrents_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.schedulecurrents_id_seq', 3, true);


--
-- TOC entry 3425 (class 0 OID 0)
-- Dependencies: 224
-- Name: schedulestandart_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.schedulestandart_id_seq', 9, true);


--
-- TOC entry 3426 (class 0 OID 0)
-- Dependencies: 218
-- Name: studygroups_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.studygroups_id_seq', 3, true);


--
-- TOC entry 3427 (class 0 OID 0)
-- Dependencies: 222
-- Name: subjects_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.subjects_id_seq', 6, true);


--
-- TOC entry 3428 (class 0 OID 0)
-- Dependencies: 214
-- Name: teachers_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.teachers_id_seq', 2, true);


--
-- TOC entry 3429 (class 0 OID 0)
-- Dependencies: 220
-- Name: weekdays_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.weekdays_id_seq', 6, true);


--
-- TOC entry 3219 (class 2606 OID 16427)
-- Name: cabinets cabinets_name_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.cabinets
    ADD CONSTRAINT cabinets_name_key UNIQUE (name);


--
-- TOC entry 3221 (class 2606 OID 16425)
-- Name: cabinets cabinets_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.cabinets
    ADD CONSTRAINT cabinets_pkey PRIMARY KEY (id);


--
-- TOC entry 3239 (class 2606 OID 16515)
-- Name: schedulechanged schedulechanged_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.schedulechanged
    ADD CONSTRAINT schedulechanged_pkey PRIMARY KEY (id);


--
-- TOC entry 3237 (class 2606 OID 16503)
-- Name: schedulecurrents schedulecurrents_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.schedulecurrents
    ADD CONSTRAINT schedulecurrents_pkey PRIMARY KEY (id);


--
-- TOC entry 3235 (class 2606 OID 16469)
-- Name: schedulestandart schedulestandart_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.schedulestandart
    ADD CONSTRAINT schedulestandart_pkey PRIMARY KEY (id);


--
-- TOC entry 3223 (class 2606 OID 16438)
-- Name: studygroups studygroups_name_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.studygroups
    ADD CONSTRAINT studygroups_name_key UNIQUE (name);


--
-- TOC entry 3225 (class 2606 OID 16436)
-- Name: studygroups studygroups_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.studygroups
    ADD CONSTRAINT studygroups_pkey PRIMARY KEY (id);


--
-- TOC entry 3231 (class 2606 OID 16460)
-- Name: subjects subjects_name_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.subjects
    ADD CONSTRAINT subjects_name_key UNIQUE (name);


--
-- TOC entry 3233 (class 2606 OID 16458)
-- Name: subjects subjects_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.subjects
    ADD CONSTRAINT subjects_pkey PRIMARY KEY (id);


--
-- TOC entry 3217 (class 2606 OID 16416)
-- Name: teachers teachers_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.teachers
    ADD CONSTRAINT teachers_pkey PRIMARY KEY (id);


--
-- TOC entry 3227 (class 2606 OID 16449)
-- Name: weekdays weekdays_name_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.weekdays
    ADD CONSTRAINT weekdays_name_key UNIQUE (name);


--
-- TOC entry 3229 (class 2606 OID 16447)
-- Name: weekdays weekdays_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.weekdays
    ADD CONSTRAINT weekdays_pkey PRIMARY KEY (id);


--
-- TOC entry 3246 (class 2606 OID 16526)
-- Name: schedulechanged schedulechanged_cabinet_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.schedulechanged
    ADD CONSTRAINT schedulechanged_cabinet_fkey FOREIGN KEY (cabinet) REFERENCES public.cabinets(id) ON DELETE CASCADE;


--
-- TOC entry 3247 (class 2606 OID 16531)
-- Name: schedulechanged schedulechanged_schedulecurrent_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.schedulechanged
    ADD CONSTRAINT schedulechanged_schedulecurrent_fkey FOREIGN KEY (schedulecurrent) REFERENCES public.schedulecurrents(id) ON DELETE CASCADE;


--
-- TOC entry 3248 (class 2606 OID 16544)
-- Name: schedulechanged schedulechanged_studygroup_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.schedulechanged
    ADD CONSTRAINT schedulechanged_studygroup_fkey FOREIGN KEY (studygroup) REFERENCES public.studygroups(id);


--
-- TOC entry 3249 (class 2606 OID 16549)
-- Name: schedulechanged schedulechanged_subject_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.schedulechanged
    ADD CONSTRAINT schedulechanged_subject_fkey FOREIGN KEY (subject) REFERENCES public.subjects(id);


--
-- TOC entry 3250 (class 2606 OID 16521)
-- Name: schedulechanged schedulechanged_teacher_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.schedulechanged
    ADD CONSTRAINT schedulechanged_teacher_fkey FOREIGN KEY (teacher) REFERENCES public.teachers(id) ON DELETE CASCADE;


--
-- TOC entry 3245 (class 2606 OID 16504)
-- Name: schedulecurrents schedulecurrents_weekday_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.schedulecurrents
    ADD CONSTRAINT schedulecurrents_weekday_fkey FOREIGN KEY (weekday) REFERENCES public.weekdays(id);


--
-- TOC entry 3240 (class 2606 OID 16485)
-- Name: schedulestandart schedulestandart_cabinet_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.schedulestandart
    ADD CONSTRAINT schedulestandart_cabinet_fkey FOREIGN KEY (cabinet) REFERENCES public.cabinets(id) ON DELETE CASCADE;


--
-- TOC entry 3241 (class 2606 OID 16470)
-- Name: schedulestandart schedulestandart_studygroup_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.schedulestandart
    ADD CONSTRAINT schedulestandart_studygroup_fkey FOREIGN KEY (studygroup) REFERENCES public.studygroups(id) ON DELETE CASCADE;


--
-- TOC entry 3242 (class 2606 OID 16475)
-- Name: schedulestandart schedulestandart_subject_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.schedulestandart
    ADD CONSTRAINT schedulestandart_subject_fkey FOREIGN KEY (subject) REFERENCES public.subjects(id) ON DELETE CASCADE;


--
-- TOC entry 3243 (class 2606 OID 16480)
-- Name: schedulestandart schedulestandart_teacher_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.schedulestandart
    ADD CONSTRAINT schedulestandart_teacher_fkey FOREIGN KEY (teacher) REFERENCES public.teachers(id) ON DELETE CASCADE;


--
-- TOC entry 3244 (class 2606 OID 16490)
-- Name: schedulestandart schedulestandart_weekday_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.schedulestandart
    ADD CONSTRAINT schedulestandart_weekday_fkey FOREIGN KEY (weekday) REFERENCES public.weekdays(id) ON DELETE CASCADE;


-- Completed on 2023-05-18 15:12:42

--
-- PostgreSQL database dump complete
--

