-- --
-- --
create or replace view vw_roles(role_id, role_name) as
select r.role_id,
       r.role_name
from roles r;

alter table vw_roles
    owner to postgres;


-- --
-- --
create or replace view vw_usuario
            (usuario_id, nombre, apellidos, correo, nombre_usuario,
             fh_registro, fh_modificacion, usr_registra_id, usr_modifica_id)
as
select u.usuario_id,
--        m.role_id,
--        r.role_name,
--        m.mid,
--        m.auth,
--        (u.nombre::text || ' '::text) || u.apellidos::text as usuario,
       u.nombre,
       u.apellidos,
       u.correo,
       u.nombre_usuario,
--        m.password,
--        acc.activity_status                                as activo,
--        acc.is_staff                                       as tipo_usuario,
--        CasE acc.is_staff > 1
--            WHEN true THEN 'Usuario Online'::varchar
--            ELSE 'Empleado'::varchar
--            END                                            as tipo_usuario_txt,
       u.fh_registro,
       u.fh_modificacion,
       u.usr_registra_id,
--        CasE m.usr_registra_id = 0
--            WHEN TRUE THEN 'N/A'::text
--            ELSE
--                (u2.nombre::text || ' '::text) || (u2.apellidos::text || ' '::text)
--            END                                            as usr_registra,
       u.usr_modifica_id
--        CasE m.usr_modifica_id = 0
--            WHEN TRUE THEN 'N/A'::text
--            ELSE
--                (u3.nombre::text || ' '::text) || (u3.apellidos::text || ' '::text)
--            END                                            as usr_modifica

from usuario u;
--          LEFT JOIN tower m on u.usuario_id = m.usuario_id
--          LEFT JOIN usuario u2 ON u.usr_registra_id = u2.usuario_id
--          LEFT JOIN usuario u3 ON u.usr_modifica_id = u3.usuario_id
--          LEFT JOIN user_access acc ON u.usuario_id = acc.usuario_id
--          LEFT JOIN roles r ON m.role_id = r.role_id;

alter table vw_usuario
    owner to postgres;


create or replace view vw_user_access
            (user_access_id, usuario_id, mid, auth, created_at, last_login, activity_status, is_staff, operation_id,
             operation_context_id, fh_registro, fh_modificacion, fh_activacion, usr_registra_id,
             usr_modifica_id, usr_activa_id)
as
select ua.user_access_id,
       ua.usuario_id,
       ua.mid,
       ua.auth,
       ua.created_at,
       ua.last_login,
       ua.activity_status,
       ua.is_staff,
       ua.operation_id,
       ua.operation_context_id,
       ua.fh_registro,
       ua.fh_modificacion,
       ua.fh_activacion,
       ua.usr_registra_id,
--        CasE ua.usr_modifica_id = 0
--            WHEN TRUE THEN 'N/A'::text
--            ELSE
--                (u2.nombre::text || ' '::text) || (u2.apellidos::text || ' '::text)
--            END                                 as usr_registra,
       ua.usr_modifica_id,
--        CasE ua.usr_modifica_id = 0
--            WHEN TRUE THEN 'N/A'::text
--            ELSE
--                (u3.nombre::text || ' '::text) || (u3.apellidos::text || ' '::text)
--            END                                 as usr_modifica,
       ua.usr_activa_id
--        CasE ua.usr_activa_id = 0
--            WHEN TRUE THEN 'N/A'::text
--            ELSE
--                (u4.nombre::text || ' '::text) || (u4.apellidos::text || ' '::text)
--            END                                 as usr_activa
from user_access ua
         LEFT JOIN conceptos cop1 ON ua.operation_id = cop1.concepto_id
         LEFT JOIN conceptos cop2 ON ua.operation_context_id = cop2.concepto_id
         LEFT JOIN usuario u2 ON ua.usr_registra_id = u2.usuario_id
         LEFT JOIN usuario u3 ON ua.usr_modifica_id = u3.usuario_id
         LEFT JOIN usuario u4 ON ua.usr_activa_id = u4.usuario_id
         LEFT JOIN usuario u1 ON ua.usuario_id = u1.usuario_id;

alter table vw_user_access
    owner to postgres;


create or replace view vw_usuario_inicio_sesion
            (usuario_id, mid, auth, nombre, apellidos, correo,
             nombre_usuario, clave_acceso,
             fh_registro, fh_modificacion, usr_registro_id, usr_modifico_id)
as
select u.usuario_id,
       ua.mid,
       ua.auth,
--        u.usuario,
       u.nombre,
       u.apellidos,
       u.correo,
       u.nombre_usuario,
       m.pass  as clave_acceso,
--        u.activo,
--        CasE u.activo
--            WHEN true THEN 'SI'::varchar
--            ELSE 'NO'::varchar
--            END as activo_txt,
--        u.tipo_usuario,
--        CasE u.tipo_usuario > 1
--            WHEN true THEN 'Usuario Online'::varchar
--            ELSE 'Empleado'::varchar
--            END as tipo_usuario_txt,
       u.fh_registro,
       u.fh_modificacion,
       u.usr_registra_id,
       u.usr_modifica_id

from vw_usuario u
         JOIN user_access ua ON u.usuario_id = ua.usuario_id
         JOIN tower m ON u.usuario_id = m.usuario_id;

alter table vw_usuario_inicio_sesion
    owner to postgres;


create or replace view vw_conceptos(cnpto_padre_id, concepto, orden, concepto_id) as
select c.cnpto_padre_id,
       c.concepto,
       c.orden,
       c.concepto_id
from conceptos c
ORDER BY concepto_id DESC;

alter table vw_conceptos
    owner to postgres;


create or replace view vw_cliente
            (cliente_id, user_access_id, sucursal_id, nombre, apellidos, correo, tel_1, c_credito,
             c_ahorro, fh_registro, fh_modificacion, fh_autorizacion, usr_registra_id, usr_modifica_id,
             usr_autoriza_id)
as
select cliente.cliente_id,
       cliente.user_access_id,
--        ua.usuario_id,
--        ua.mid,
--        ua.auth,
       cliente.sucursal_id,
--        s.abr_sucursal,
--        (cliente.nombre::text || cliente.apellidos::text) as cliente,
       cliente.nombre,
       cliente.apellidos,
       cliente.correo,
       cliente.tel_1,
--        ua.activity_status                                as activo,
--        CASE ua.activity_status
--            WHEN true
--                THEN 'Cliente Activo'::VARCHAR
--            ELSE 'Cliente Inactivo'::VARCHAR
--            END                                           AS activo_txt,
--        ua.is_staff                                       as tipo_usuario,
--        CasE ua.is_staff > 1
--            WHEN true THEN 'Usuario Online'::VARCHAR
--            ELSE 'Empleado'::VARCHAR
--            END                                           as tipo_usuario_txt,
       cliente.c_credito,
--        CasE cliente.c_credito
--            WHEN TRUE THEN 'CON Credito'::VARCHAR
--            ELSE 'SIN Credito'::VARCHAR
--            END                                           AS c_credito_txt,
       cliente.c_ahorro,
--        CasE cliente.c_ahorro
--            WHEN TRUE THEN 'CON Ahorro'::VARCHAR
--            ELSE 'SIN Ahorro'::VARCHAR
--            END                                           AS c_ahorro_txt,
       cliente.fh_registro,
       cliente.fh_modificacion,
       cliente.fh_autorizacion,
       cliente.usr_registra_id,
       cliente.usr_modifica_id,
       cliente.usr_autoriza_id

from cliente
--          LEFT JOIN sucursal s ON cliente.sucursal_id = s.sucursal_id
--          LEFT JOIN user_access ua ON cliente.user_access_id = ua.user_access_id
;

alter table vw_cliente
    owner to postgres;



create or replace view vw_personal
            (personal_id, user_access_id, apellidos, nombre, funcion_id, fh_registro, fh_modificacion, fh_autorizacion,
             usr_registra_id, usr_modifica_id, usr_autoriza_id)
as
select p.personal_id,
       p.user_access_id,
       p.apellidos,
       p.nombre,
       p.funcion_id,
       p.fh_registro,
       p.fh_modificacion,
       p.fh_autorizacion,
       p.usr_registra_id,
       p.usr_modifica_id,
       p.usr_autoriza_id

from personal p
         LEFT JOIN user_access ua ON p.user_access_id = ua.user_access_id
         LEFT JOIN tower m ON ua.mid = m.mid
         LEFT JOIN roles r ON m.role_id = r.role_id
         LEFT JOIN sucursal s ON p.sucursal_id = s.sucursal_id
         LEFT JOIN conceptos cnp ON s.entidad_id = cnp.concepto_id
         LEFT JOIN conceptos f ON p.funcion_id = f.concepto_id
         LEFT JOIN vw_usuario u ON ua.usuario_id = u.usuario_id
         LEFT JOIN vw_usuario ureg ON p.usr_registra_id = ureg.usuario_id
         LEFT JOIN vw_usuario umod ON p.usr_modifica_id = umod.usuario_id
         LEFT JOIN vw_usuario uath ON p.usr_autoriza_id = uath.usuario_id;

alter table vw_personal
    owner to postgres;



create or replace view vw_transaccion
            (transaction_id, folio, cliente_id, sucursal_id, nombre_sucursal, fh_registro, fh_modificacion,
             usr_registra_id,
             usr_registra, usr_modifica_id, usr_modifica)
as
SELECT t.transaction_id,
       t.folio,
       t.cliente_id,
       t.sucursal_id,
       s.nombre_sucursal,
       t.fh_registro,
       t.fh_modificacion,
       t.usr_registra_id,
       COALESCE(vu1.nombre_usuario, 'N/A'::character varying) as usr_registra,
       t.usr_modifica_id,
       COALESCE(vu2.nombre_usuario, 'N/A'::character varying) as usr_modifica

FROM transaction t
         LEFT JOIN vw_usuario vu1 ON t.usr_registra_id = vu1.usuario_id
         LEFT JOIN vw_usuario vu2 ON t.usr_modifica_id = vu2.usuario_id
         LEFT JOIN vw_cliente vc ON t.cliente_id = vc.cliente_id
         LEFT JOIN sucursal s ON t.sucursal_id = s.sucursal_id;

alter table vw_transaccion
    owner to postgres;


create or replace view vw_transaccion_credito
            (credit_id, transaction_id, documento_id, documento_txt, nombre_sucursal, cobrado, por_cobrar,
             cobrado_txt, total, fh_registro, fh_modificacion, usr_registra_id, usr_registra, usr_modifica_id,
             usr_modifica)
as
SELECT t.credit_id,
       t.transaction_id,
       t.documento_id,
       cc.concepto                                            AS documento_txt,
       s.nombre_sucursal,
       t.cobrado,
       t.por_cobrar,
       CASE
           WHEN t.por_cobrar = 0 THEN 'Ha sido cobrado'::text
           WHEN t.cobrado = 0 THEN 'No ha sido cobrado'::text
           WHEN t.cobrado > 0 THEN 'Falta por cobrar'::text
           ELSE NULL::text
           END                                                as cobrado_txt,
       t.total,
       t2.fh_registro,
       t2.fh_modificacion,
       t2.usr_registra_id,
       COALESCE(vu1.nombre_usuario, 'N/A'::character varying) as usr_registra,
       t2.usr_modifica_id,
       COALESCE(vu2.nombre_usuario, 'N/A'::character varying) as usr_modifica

FROM transaction_credit t
         LEFT JOIN conceptos cc ON t.documento_id = cc.concepto_id
         LEFT JOIN transaction t2 on t.transaction_id = t2.transaction_id
         LEFT JOIN vw_usuario vu1 ON t2.usr_registra_id = vu1.usuario_id
         LEFT JOIN vw_usuario vu2 ON t2.usr_modifica_id = vu2.usuario_id
         LEFT JOIN vw_cliente vc ON t2.cliente_id = vc.cliente_id
         LEFT JOIN sucursal s ON t2.sucursal_id = s.sucursal_id;

alter table vw_transaccion_credito
    owner to postgres;



create or replace view vw_transaccion_ahorro
            (saving_id, transaction_id, documento_id, documento_txt, nombre_sucursal, cantidad, total,
             fh_registro, fh_modificacion, usr_registra_id, usr_registra, usr_modifica_id, usr_modifica)
as
SELECT t.saving_id,
       t.transaction_id,
       t.documento_id,
       cc.concepto                                            AS documento_txt,
       s.nombre_sucursal,
       t.cantidad,
       t.total,
       t2.fh_registro,
       t2.fh_modificacion,
       t2.usr_registra_id,
       COALESCE(vu1.nombre_usuario, 'N/A'::character varying) as usr_registra,
       t2.usr_modifica_id,
       COALESCE(vu2.nombre_usuario, 'N/A'::character varying) as usr_modifica

FROM transaction_saving t
         LEFT JOIN conceptos cc ON t.documento_id = cc.concepto_id
         LEFT JOIN transaction t2 on t.transaction_id = t2.transaction_id
         LEFT JOIN vw_usuario vu1 ON t2.usr_registra_id = vu1.usuario_id
         LEFT JOIN vw_usuario vu2 ON t2.usr_modifica_id = vu2.usuario_id
         LEFT JOIN vw_cliente vc ON t2.cliente_id = vc.cliente_id
         LEFT JOIN sucursal s ON t2.sucursal_id = s.sucursal_id;

alter table vw_transaccion_ahorro
    owner to postgres;



