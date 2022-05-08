CREATE EXTENSION IF NOT EXISTS "uuid-ossp";
-- SELECT uuid_generate_v4();


create sequence roles_id_seq;
alter sequence roles_id_seq owner to postgres;
create table roles
(
    role_id   integer               not null default nextval('roles_id_seq'::regclass),
    role_name character varying(35) not null default ''::character varying UNIQUE,
    primary key (role_id)
);

alter table roles
    owner to postgres;



create sequence usuario_id_seq;
alter sequence usuario_id_seq owner to postgres;
create table usuario
(
    usuario_id      integer               not null default nextval('usuario_id_seq'::regclass),
    nombre          character varying(30) not null default ''::character varying,
    apellidos       character varying(60) not null default ''::character varying,
    correo          character varying(50) not null default ''::character varying,
    nombre_usuario  character varying(20) not null,
    fh_registro     timestamptz                    default NOW()::timestamptz,
    fh_modificacion timestamptz                    default NOW()::timestamptz,
    usr_registra_id integer               not null default 0,
    usr_modifica_id integer               not null default 0,
    primary key (usuario_id),
    unique (usuario_id)
);
alter table usuario
    owner to postgres;

create sequence tower_id_seq;
alter sequence tower_id_seq owner to postgres;
create table tower
(
    tower_id        integer               not null default nextval('tower_id_seq'::regclass),
    role_id         integer               not null,
    usuario_id      integer               not null UNIQUE,
    mid             uuid                  not null UNIQUE,
    auth            varchar(100)          not null UNIQUE,
    pass            character varying(90) not null default ''::character varying,
    is_staff        integer               not null default 0,
    fh_registro     timestamptz                    default NOW()::timestamptz,
    fh_modificacion timestamptz                    default NOW()::timestamptz,
    usr_registra_id integer               not null default 0,
    usr_modifica_id integer               not null default 0,
    primary key (tower_id),
    foreign key (usuario_id) references usuario (usuario_id),
    foreign key (role_id) references roles (role_id),
    unique (usuario_id, mid, auth)
);

alter table tower
    owner to postgres;

create sequence user_access_id_seq;
alter sequence user_access_id_seq owner to postgres;
create table user_access
(
    user_access_id       integer      not null default nextval('user_access_id_seq'::regclass) UNIQUE,
    usuario_id           integer      not null UNIQUE,
    mid                  uuid         not null UNIQUE,
    auth                 varchar(100) not null UNIQUE,
    created_at           timestamptz  not null default NOW()::timestamptz,
    last_login           timestamptz  not null default NOW()::timestamptz,
    activity_status      boolean      not null default false::boolean,
    is_staff             integer      not null default 0,
    operation_id         integer      not null default 0,
    operation_context_id integer      not null default 0,
    fh_registro          timestamptz           default NOW()::timestamptz,
    fh_modificacion      timestamptz           default NOW()::timestamptz,
    fh_activacion        timestamptz           default NOW()::timestamptz,
    usr_registra_id      integer      not null default 0,
    usr_modifica_id      integer      not null default 0,
    usr_activa_id        integer      not null default 0,
    primary key (user_access_id),
    foreign key (usuario_id, mid, auth) references tower (usuario_id, mid, auth) on delete cascade on update cascade
);
alter table user_access
    owner to postgres;



create sequence personal_id_seq;
alter sequence personal_id_seq owner to postgres;
create table personal
(
    personal_id     integer not null default nextval('personal_id_seq'::regclass),
    user_access_id  integer not null,
    apellidos       varchar(20)      default ''::character varying not null,
    nombre          varchar(30)      default ''::character varying not null,
    sucursal_id     integer not null default 0,
    funcion_id      integer not null default 0,
    fh_registro     timestamptz      default NOW()::timestamptz,
    fh_autorizacion timestamptz      default NOW()::timestamptz,
    fh_modificacion timestamptz      default NOW()::timestamptz,
    usr_registra_id integer not null default 0,
    usr_autoriza_id integer not null default 0,
    usr_modifica_id integer not null default 0,
    constraint personal_key primary key (personal_id),
    foreign key (user_access_id) references user_access (user_access_id) on update cascade
);
alter table personal
    owner to postgres;



create sequence cliente_id_seq;
alter sequence cliente_id_seq owner to postgres;
create table cliente
(
    cliente_id      integer                                   not null default nextval('cliente_id_seq'::regclass),
    user_access_id  integer                                   not null,
    sucursal_id     integer     default 0                     not null,
    nombre          varchar(30) default ''::character varying not null,
    apellidos       varchar(20) default ''::character varying not null,
    correo          varchar(50) default ''::character varying not null,
    tel_1           varchar(10) default ''::character varying not null,
    c_credito       boolean     default false                 not null,
    c_ahorro        boolean     default false                 not null,
    fh_registro     timestamptz default NOW()::timestamptz,
    fh_modificacion timestamptz default NOW()::timestamptz,
    fh_autorizacion timestamptz default NOW()::timestamptz,
    usr_registra_id integer                                   not null default 0,
    usr_modifica_id integer                                   not null default 0,
    usr_autoriza_id integer                                   not null default 0,
    constraint cliente_key primary key (cliente_id),
    foreign key (user_access_id) references user_access (user_access_id)
);

alter table cliente
    owner to postgres;


-- --
-- -- tabla conceptos
create sequence conceptos_id_seq;
alter sequence conceptos_id_seq owner to postgres;
create table conceptos
(
    cnpto_padre_id integer      not null default 0,
    concepto       varchar(100) not null default 0,
    orden          smallint     not null default 0,
    concepto_id    integer      not null default 0,
    constraint conceptos_key primary key (concepto_id)
);

alter table conceptos
    owner to postgres;


create sequence transaction_id_seq;
alter sequence transaction_id_seq
    owner to postgres;
create table transaction
(
    transaction_id  integer not null default nextval('transaction_id_seq'::regclass),
    folio           integer not null,
    cliente_id      integer not null,
    sucursal_id     integer not null,
    fh_registro     timestamptz      default NOW()::timestamptz,
    fh_modificacion timestamptz      default NOW()::timestamptz,
    usr_registra_id integer not null default 0,
    usr_modifica_id integer not null default 0,
    constraint transaction_key primary key (transaction_id)
--     foreign key (cliente_id) references cliente (cliente_id)
);

alter table transaction
    owner to postgres;


create sequence transaction_credit_id_seq;
alter sequence transaction_credit_id_seq
    owner to postgres;
create table transaction_credit
(
    credit_id      integer not null default nextval('transaction_credit_id_seq'::regclass),
    transaction_id integer not null,
    documento_id   integer not null default 0,
    cobrado        numeric not null,
    por_cobrar     numeric not null,
    total          numeric          default 0 not null,
    status_id      integer not null,
    constraint transaction_credit_key primary key (credit_id),
    foreign key (transaction_id) references transaction (transaction_id)
);

alter table transaction_credit
    owner to postgres;


create sequence transaction_saving_id_seq;
alter sequence transaction_saving_id_seq
    owner to postgres;
create table transaction_saving
(
    saving_id      integer not null default nextval('transaction_saving_id_seq'::regclass),
    transaction_id integer not null,
    documento_id   integer not null default 0,
    cantidad       numeric not null,
    total          numeric          default 0 not null,
    constraint transaction_saving_key primary key (saving_id),
    foreign key (transaction_id) references transaction (transaction_id)
);

alter table transaction_saving
    owner to postgres;

create sequence sucursal_id_seq;
alter sequence sucursal_id_seq owner to postgres;
create table sucursal
(
    sucursal_id          integer not null default nextval('sucursal_id_seq'::regclass),
    sucursal_status      boolean not null default false,
    sucursal_cancelada   boolean not null default false,
    residencia_fiscal_id integer          default 0 not null,
    entidad_id           integer not null,
    nombre_sucursal      varchar(40)      default ''::character varying not null,
    abr_sucursal         varchar(6)       default ''::character varying not null,
    direccion            varchar(60)      default ''::character varying not null,
    telefono             varchar(17)      default ''::character varying not null,
    cuentas_correo       varchar(100)     default ''::character varying not null,
    fh_registro          timestamptz      default NOW()::timestamptz,
    fh_modificacion      timestamptz      default NOW()::timestamptz,
    fh_cancelacion       timestamptz      default NOW()::timestamptz,
    fh_activacion        timestamptz      default NOW()::timestamptz,
    usr_registra_id      integer not null default 0,
    usr_modifica_id      integer not null default 0,
    usr_cancela_id       integer not null default 0,
    usr_activa_id        integer not null default 0,
    constraint sucursal_key primary key (sucursal_id)
);

alter table sucursal
    owner to postgres;

