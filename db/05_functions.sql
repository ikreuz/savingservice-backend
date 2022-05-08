-- ----------------------------------------------------------------------------------- --
create or replace function fn_rol_insertar(_role_id integer, _role_name character varying)
    returns integer
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_rol_insertar
OBJETIVO:
RETORNA:
******************************************************************************/
DECLARE
    __RW          integer;
    __tmp_role_id roles.role_id%TYPE;
    __return      integer := -1;
BEGIN
    IF (select exists(select 1 from roles where role_id = _role_id)) THEN
        __return := -2; --- ya existe
    ELSE
        __return := 1;
    END IF;

    IF __return = 1 THEN

        INSERT INTO roles (role_id, role_name)
        VALUES (_role_id, _role_name);

        GET DIAGNOSTICS __RW = ROW_COUNT;

        IF __RW = 1 THEN
            __tmp_role_id = (SELECT nextval('roles_id_seq'));

            __return := __tmp_role_id;
        ELSE
            __return := 1;
        END IF;
    END IF;
    RETURN __return;
END
$$;
alter function fn_rol_insertar(integer, varchar) owner to postgres;

-- ----------------------------------------------------------------------------------- --
create or replace function fn_rol_actualizar(_role_id integer, _role_name character varying) returns integer
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_rol_actualizar
OBJETIVO:
RETORNA:
******************************************************************************/
DECLARE
    __RW     integer;
    __return integer := -1;
BEGIN

    UPDATE roles
    SET role_id   = _role_id,
        role_name = _role_name
    WHERE role_id = _role_id;

    GET DIAGNOSTICS __RW = ROW_COUNT;

    IF __RW = 1 THEN --- Se obtuvo éxito al actualizar.
        __return := 1;
    ELSE
        __return := -2;
    END IF;

    RETURN __return;
END
$$;
alter function fn_rol_actualizar (integer, varchar) owner to postgres;


-- ----------------------------------------------------------------------------------- --
create or replace function fn_rol_obtener_listado()
    returns TABLE
            (
                role_id     integer,
                role_name   character varying,
                total_count bigint
            )
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_rol_obtener_listado
OBJETIVO:
RETORNA:
******************************************************************************/
DECLARE
    __record record;
    __query  text;
BEGIN

    __query := 'SELECT * ,COUNT(role_id) OVER() AS total_count FROM roles ORDER BY role_id DESC';

    FOR __record IN EXECUTE __query
        LOOP
            role_id := __record.role_id;
            role_name := __record.role_name;
            total_count := __record.total_count;
            RETURN NEXT;
        END LOOP;
END;
$$;
alter function fn_rol_obtener_listado() owner to postgres;


-- ----------------------------------------------------------------------------------- --
create or replace function fn_rol_obtener_id(_role_id integer) returns SETOF roles
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_rol_obtener_id
OBJETIVO:
RETORNA:
******************************************************************************/
DECLARE
    __record roles;
BEGIN
    FOR __record IN SELECT * FROM roles WHERE role_id = _role_id
        LOOP
            RETURN NEXT __record;
        END LOOP;
END ;
$$;
alter function fn_rol_obtener_id(integer) owner to postgres;

-- ----------------------------------------------------------------------------------- --
create or replace function fn_rol_obtener_ultimo_id()
    RETURNS integer
    language plpgsql
AS
$$
/******************************************************************************
NOMBRE: fn_rol_obtener_ultimo_id
OBJETIVO: Busca un usuario por id.
******************************************************************************/
DECLARE
BEGIN
    RETURN (SELECT role_id AS role_id FROM roles ORDER BY role_id DESC LIMIT 1);
END
$$;
alter function fn_rol_obtener_ultimo_id() owner to postgres;

-- ----------------------------------------------------------------------------------- --
-- Funcion eliminar un rol por id
create or replace function fn_rol_eliminar_id(_role_id integer) returns integer
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_rol_eliminar_id
OBJETIVO:
RETORNA:
******************************************************************************/
DECLARE
    __RW     integer;
    __return integer := -1;
BEGIN
    DELETE FROM roles WHERE role_id = _role_id;
    GET DIAGNOSTICS __RW = ROW_COUNT;

    IF __RW = 1 THEN --- Se obtuvo éxito al actualizar.
        __return := 1;
    ELSE
        __return := -2;
    END IF;

    RETURN __return;
END;
$$;
alter function fn_rol_eliminar_id(integer) owner to postgres;

-- ----------------------------------------------------------------------------------- --
-- ----------------------------------------------------------------------------------- --
-- ----------------------------------------------------------------------------------- --
create or replace function fn_usuario_insertar(
    _usuario_id integer, _nombre character varying, _apellidos character varying,
    _correo character varying, _nombre_usuario character varying, _fh_registro timestamptz,
    _fh_modificacion timestamptz,
    _usr_registra_id integer, _usr_modifica_id integer
) returns integer
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_usuario_insertar
OBJETIVO:
RETORNA:
******************************************************************************/
DECLARE
    __RW             integer;
    __tmp_usuario_id usuario.usuario_id%TYPE;
    __return         integer := -1;
BEGIN
    INSERT INTO usuario (usuario_id, nombre, apellidos, correo, nombre_usuario,
                         fh_registro, fh_modificacion, usr_registra_id, usr_modifica_id)
    VALUES (_usuario_id, _nombre, _apellidos, _correo, _nombre_usuario,
            _fh_registro, _fh_modificacion, _usr_registra_id, _usr_modifica_id);
    GET DIAGNOSTICS __RW = ROW_COUNT;
    --- Se obtuvo éxito al insertar.
    IF __RW = 1 THEN
        -- Obtenemos el identificador del cliente.
        __tmp_usuario_id = (SELECT nextval('usuario_id_seq'));
        __return := __tmp_usuario_id;
    ELSE
        __return := -1;
    END IF;

    RETURN __return;
END
$$;
alter function fn_usuario_insertar(integer, varchar, varchar,
    varchar, varchar, timestamptz, timestamptz, integer, integer) owner to postgres;


-- ----------------------------------------------------------------------------------- --
-- Funcion actualizar usuario
create or replace function fn_usuario_actualizar(
    _usuario_id integer, _nombre character varying, _apellidos character varying,
    _correo character varying, _nombre_usuario character varying, _fh_registro timestamptz,
    _fh_modificacion timestamptz,
    _usr_registra_id integer, _usr_modifica_id integer
) returns integer
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_usuario_actualizar
OBJETIVO:
RETORNA:
******************************************************************************/
DECLARE
    __RW     integer;
    __return integer := -1;
BEGIN

    UPDATE usuario
    SET usuario_id      = _usuario_id,
        nombre          = _nombre,
        apellidos       = _apellidos,
        correo          = _correo,
        nombre_usuario  = _nombre_usuario,
        fh_registro     = _fh_registro,
        fh_modificacion =_fh_modificacion,
        usr_registra_id =_usr_registra_id,
        usr_modifica_id =_usr_modifica_id
    WHERE usuario_id = _usuario_id;

    GET DIAGNOSTICS __RW = ROW_COUNT;

    IF __RW = 1 THEN --- Se obtuvo éxito al actualizar.
        __return := 1;
    ELSE
        __return := -2;
    END IF;

    RETURN __return;
END
$$;
alter function fn_usuario_actualizar
    (integer, varchar, varchar, varchar, varchar, timestamptz, timestamptz,
        integer, integer) owner to postgres;


-- ----------------------------------------------------------------------------------- --
create or replace function fn_usuario_obtener_listado()
    returns TABLE
            (
                usuario_id      integer,
                nombre          character varying,
                apellidos       character varying,
                correo          character varying,
                nombre_usuario  character varying,
                fh_registro     timestamptz,
                fh_modificacion timestamptz,
                usr_registra_id integer,
                usr_modifica_id integer,
                total_count     bigint
            )
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_usuario_obtener_listado
OBJETIVO:
RETORNA:
******************************************************************************/
DECLARE
    __record record;
    __query  text;
BEGIN

    __query := 'SELECT * ,COUNT(usuario_id) OVER() AS total_count FROM usuario ORDER BY usuario_id DESC';

    FOR __record IN EXECUTE __query
        LOOP
            usuario_id := __record.usuario_id;
            nombre := __record.nombre;
            apellidos := __record.apellidos;
            correo := __record.correo;
            nombre_usuario := __record.nombre_usuario;
            fh_registro := __record.fh_registro;
            fh_modificacion := __record.fh_modificacion;
            usr_registra_id := __record.usr_registra_id;
            usr_modifica_id := __record.usr_modifica_id;
            total_count := __record.total_count;
            RETURN NEXT;
        END LOOP;
END;
$$;
alter function fn_usuario_obtener_listado() owner to postgres;


-- ----------------------------------------------------------------------------------- --
create or replace function fn_usuario_obtener_id(_usuario_id integer) returns SETOF usuario
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_usuario_obtener_id
OBJETIVO:
RETORNA:
******************************************************************************/
DECLARE
    __record usuario;
BEGIN
    FOR __record IN SELECT * FROM usuario WHERE usuario_id = _usuario_id
        LOOP
            RETURN NEXT __record;
        END LOOP;
END;
$$;
alter function fn_usuario_obtener_id(integer) owner to postgres;

-- ----------------------------------------------------------------------------------- --
create or replace function fn_usuario_obtener_ultimo_id()
    RETURNS integer
    language plpgsql
AS
$$
/******************************************************************************
NOMBRE: fn_usuario_obtener_ultimo_id
OBJETIVO:
******************************************************************************/
DECLARE
BEGIN
    RETURN (SELECT usuario_id AS usuario_id FROM usuario ORDER BY usuario_id DESC LIMIT 1);
END
$$;
alter function fn_usuario_obtener_ultimo_id() owner to postgres;


-- ----------------------------------------------------------------------------------- --
create or replace function fn_usuario_eliminar_id(_usuario_id integer) returns integer
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_usuario_eliminar_id
OBJETIVO:
RETORNA:
******************************************************************************/
DECLARE
    __RW     integer;
    __return integer := -1;
BEGIN

    DELETE FROM usuario WHERE usuario_id = _usuario_id;
    GET DIAGNOSTICS __RW = ROW_COUNT;

    IF __RW = 1 THEN --- Se obtuvo éxito al actualizar.
        __return := 1;
    ELSE
        __return := -2;
    END IF;

    RETURN __return;
END;
$$;
alter function fn_usuario_eliminar_id(integer) owner to postgres;

-- ----------------------------------------------------------------------------------- --
-- ----------------------------------------------------------------------------------- --
-- ----------------------------------------------------------------------------------- --
create or replace function fn_personal_insertar(
    _personal_id integer, _user_access_id integer, _apellidos character varying, _nombre character varying,
    _sucursal_id integer, _funcion_id integer, _fh_registro timestamptz,
    _fh_autorizacion timestamptz, _fh_modificacion timestamptz,
    _usr_registra_id integer, _usr_autoriza_id integer, _usr_modifica_id integer
) returns integer
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_personal_insertar
OBJETIVO:
RETORNA:
******************************************************************************/
DECLARE
    __RW              integer;
    __tmp_personal_id personal.personal_id%TYPE;
    __return          integer := -1;
BEGIN

    INSERT INTO personal(personal_id, user_access_id, apellidos, nombre, sucursal_id, funcion_id, fh_registro,
                         fh_autorizacion, fh_modificacion, usr_registra_id, usr_autoriza_id, usr_modifica_id)
    VALUES (_personal_id, _user_access_id, _apellidos, _nombre, _sucursal_id, _funcion_id, _fh_registro,
            _fh_autorizacion, _fh_modificacion, _usr_registra_id, _usr_autoriza_id, _usr_modifica_id);

    GET DIAGNOSTICS __RW = ROW_COUNT;

    IF __RW = 1 THEN
        __tmp_personal_id = (SELECT nextval('personal_id_seq'));

        __return := __tmp_personal_id;
    ELSE
        --ROLLBACK;
        __return := -1;
    END IF;

    RETURN __return;
END
$$;
alter function fn_personal_insertar( integer, integer, varchar, varchar,
    integer, integer, timestamptz, timestamptz, timestamptz, integer, integer, integer ) owner to postgres;


-- ----------------------------------------------------------------------------------- --
create or replace function fn_personal_actualizar(_personal_id integer, _user_access_id integer,
                                                  _apellidos character varying, _nombre character varying,
                                                  _sucursal_id integer, _funcion_id integer, _fh_registro timestamptz,
                                                  _fh_autorizacion timestamptz, _fh_modificacion timestamptz,
                                                  _usr_registra_id integer, _usr_autoriza_id integer,
                                                  _usr_modifica_id integer
) returns integer
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_personal_actualizar
OBJETIVO:
RETORNA:
******************************************************************************/
DECLARE
    __RW     integer;
    __return integer := -1;
BEGIN

    UPDATE personal
    SET user_access_id  = _user_access_id,
        apellidos       = _apellidos,
        nombre          = _nombre,
        sucursal_id=_sucursal_id,
        funcion_id=_funcion_id,
        fh_registro=_fh_registro,
        fh_autorizacion=_fh_autorizacion,
        fh_modificacion =_fh_modificacion,
        usr_registra_id =_usr_registra_id,
        usr_autoriza_id =_usr_autoriza_id,
        usr_modifica_id =_usr_modifica_id

    WHERE personal_id = _personal_id;

    GET DIAGNOSTICS __RW = ROW_COUNT;

    IF __RW = 1 THEN --- Se obtuvo éxito al actualizar.
        __return := 1;
    ELSE
        __return := -2;
    END IF;

    RETURN __return;
END
$$;
alter function fn_personal_actualizar( integer, integer, varchar, varchar,
    integer, integer, timestamptz, timestamptz, timestamptz, integer, integer, integer ) owner to postgres;
;
-- ----------------------------------------------------------------------------------- --
create or replace function fn_personal_obtener_listado()
    RETURNS TABLE
            (
                personal_id     integer,
                user_access_id  integer,
                apellidos       character varying,
                nombre          character varying,
                funcion_id      integer,
                fh_registro     timestamptz,
                fh_modificacion timestamptz,
                fh_autorizacion timestamptz,
                usr_registra_id integer,
                usr_modifica_id integer,
                usr_autoriza_id integer
            )
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_personal_obtener_listado
OBJETIVO:
RETORNA:
******************************************************************************/
DECLARE
    __record record;
    __query  text;
BEGIN

    __query := 'SELECT * FROM vw_personal ORDER BY personal_id DESC';

    FOR __record IN EXECUTE __query
        LOOP
            personal_id := __record.personal_id;
            user_access_id := __record.user_access_id;
            apellidos := __record.apellidos;
            nombre := __record.nombre;
            funcion_id := __record.funcion_id;
            fh_registro := __record.fh_registro;
            fh_modificacion := __record.fh_modificacion;
            fh_autorizacion := __record.fh_autorizacion;
            usr_registra_id := __record.usr_registra_id;
            usr_modifica_id := __record.usr_modifica_id;
            usr_autoriza_id := __record.usr_autoriza_id;
            RETURN NEXT;
        END LOOP;
END;
$$;
alter function fn_personal_obtener_listado() owner to postgres;

-- ----------------------------------------------------------------------------------- --
create or replace function fn_personal_conseguir_user_access_id(_personal_id integer) returns integer
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_personal_conseguir_user_access_id
OBJETIVO:
RETORNA:
******************************************************************************/
DECLARE
    __exist  integer := -1;
    __return text    := 'No existe';
BEGIN
    IF (select exists(select 1 from personal where personal_id = _personal_id)) THEN
        __exist := 1;
    ELSE
        __exist := -2;
    END IF;

    IF __exist = 1 THEN
        RETURN (SELECT user_access_id AS user_access_id FROM personal WHERE personal_id = _personal_id);
    ELSE
        RETURN __return;
    END IF;
END;
$$;
alter function fn_personal_conseguir_user_access_id(integer) owner to postgres;


create or replace function fn_personal_conseguir_mid(_personal_id integer) returns uuid
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_personal_conseguir_mid
OBJETIVO: Busca un personal por usuario id.
RETORNA: __record -
******************************************************************************/
DECLARE
    __exist  integer := -1;
    __return text    := 'No existe';
BEGIN
    IF (select exists(select 1 from personal where personal_id = _personal_id)) THEN
        __exist := 1;
    ELSE
        __exist := -2;
    END IF;

    IF __exist = 1 THEN
        RETURN (SELECT mid AS mid
                FROM user_access
                WHERE user_access_id = fn_personal_conseguir_user_access_id(_personal_id));
    ELSE
        RETURN __return;
    END IF;
END;
$$;
alter function fn_personal_conseguir_mid(integer) owner to postgres;

-- ----------------------------------------------------------------------------------- --
create or replace function fn_personal_obtener_ultimo_id()
    RETURNS integer
    language plpgsql
AS
$$
/******************************************************************************
NOMBRE: fn_personal_obtener_ultimo_id
OBJETIVO:
******************************************************************************/
DECLARE
BEGIN
    RETURN (SELECT personal_id AS personal_id FROM personal ORDER BY personal_id DESC LIMIT 1);
END
$$;
alter function fn_personal_obtener_ultimo_id() owner to postgres;


-- ----------------------------------------------------------------------------------- --
create or replace function fn_personal_eliminar_id(_personal_id integer) returns integer
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_personal_eliminar_id
OBJETIVO:
RETORNA:
******************************************************************************/
DECLARE
    __RW     integer;
    __return integer := -1;
BEGIN

    DELETE FROM personal WHERE personal_id = _personal_id;
    GET DIAGNOSTICS __RW = ROW_COUNT;

    IF __RW = 1 THEN --- Se obtuvo éxito al actualizar.
        __return := 1;
    ELSE
        __return := -2;
    END IF;

    RETURN __return;
END;
$$;
alter function fn_personal_eliminar_id(integer) owner to postgres;



-- ----------------------------------------------------------------------------------- --
-- Funcion insertar cliente
create or replace function fn_cliente_insertar(
    _cliente_id integer, _user_access_id integer, _sucursal_id integer, _nombre character varying,
    _apellidos character varying, _correo character varying, _tel_1 character varying, _c_credito boolean,
    _c_ahorro boolean, _fh_registro timestamptz, _fh_modificacion timestamptz, _fh_autorizacion timestamptz,
    _usr_registra_id integer,
    _usr_modifica_id integer, _usr_autoriza_id integer
) returns integer
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_cliente_insertar
OBJETIVO:
RETORNA:
******************************************************************************/
DECLARE
    __RW             integer;
    __tmp_cliente_id cliente.cliente_id%TYPE;
    __return         integer := -1;
BEGIN

    INSERT INTO cliente(cliente_id, user_access_id, sucursal_id, nombre, apellidos, correo, tel_1, c_credito,
                        c_ahorro, fh_registro, fh_modificacion, fh_autorizacion, usr_registra_id,
                        usr_modifica_id, usr_autoriza_id)
    VALUES (_cliente_id, _user_access_id, _sucursal_id, _nombre, _apellidos, _correo, _tel_1, _c_credito,
            _c_ahorro, _fh_registro, _fh_modificacion, _fh_autorizacion, _usr_registra_id,
            _usr_modifica_id, _usr_autoriza_id);

    GET DIAGNOSTICS __RW = ROW_COUNT;

    IF __RW = 1 THEN
        __tmp_cliente_id = (SELECT nextval('cliente_id_seq'));

        __return := __tmp_cliente_id;
    ELSE
        __return := -1;
    END IF;

    RETURN __return;
END
$$;
alter function fn_cliente_insertar( integer, integer, integer,varchar,
    varchar, varchar, varchar, boolean, boolean, timestamptz, timestamptz, timestamptz,
    integer, integer, integer) owner to postgres;


-- ----------------------------------------------------------------------------------- --
-- Funcion actualiza un cliente
create or replace function fn_cliente_actualizar(_cliente_id integer, _user_access_id integer, _sucursal_id integer,
                                                 _nombre character varying,
                                                 _apellidos character varying, _correo character varying,
                                                 _tel_1 character varying, _c_credito boolean,
                                                 _c_ahorro boolean, _fh_registro timestamptz,
                                                 _fh_modificacion timestamptz, _fh_autorizacion timestamptz,
                                                 _usr_registra_id integer,
                                                 _usr_modifica_id integer, _usr_autoriza_id integer
) returns integer
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_cliente_actualizar
OBJETIVO:
RETORNA:
******************************************************************************/
DECLARE
    __RW     integer;
    __return integer := -1;
BEGIN

    UPDATE cliente
    SET user_access_id= _user_access_id,
        sucursal_id=_sucursal_id,
        nombre=_nombre,
        apellidos= _apellidos,
        correo=_correo,
        tel_1=_tel_1,
        c_credito =_c_credito,
        c_ahorro=_c_ahorro,
        fh_registro=_fh_registro,
        fh_modificacion=_fh_modificacion,
        fh_autorizacion=_fh_autorizacion,
        usr_registra_id =_usr_registra_id,
        usr_modifica_id=_usr_modifica_id,
        usr_autoriza_id=_usr_autoriza_id
    WHERE cliente_id = _cliente_id;

    GET DIAGNOSTICS __RW = ROW_COUNT;

    IF __RW = 1 THEN --- Se obtuvo éxito al actualizar.
        __return := 1;
    ELSE
        __return := -2;
    END IF;

    RETURN __return;
END
$$;
alter function fn_cliente_actualizar( integer, integer, integer,varchar,
    varchar, varchar, varchar, boolean, boolean, timestamptz, timestamptz, timestamptz,
    integer, integer, integer) owner to postgres;

-- ----------------------------------------------------------------------------------- --
create or replace function fn_cliente_obtener_id(_cliente_id integer)
    returns SETOF vw_cliente
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_cliente_obtener_id
OBJETIVO:
RETORNA:
******************************************************************************/
DECLARE
    __record vw_cliente;
BEGIN
    FOR __record IN SELECT * FROM vw_cliente WHERE cliente_id = _cliente_id
        LOOP
            RETURN NEXT __record;
        END LOOP;
END;
$$;
alter function fn_cliente_obtener_id(integer) owner to postgres;


-- ----------------------------------------------------------------------------------- --
create or replace function fn_cliente_conseguir_user_access_id(_cliente_id integer) returns integer
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_cliente_conseguir_user_access_id
OBJETIVO:
RETORNA:
******************************************************************************/
DECLARE
    __exist  integer := 1;
    __return integer := -1;
BEGIN
    IF (select exists(select 1 from cliente where cliente_id = _cliente_id)) THEN
        __exist := 1;
    ELSE
        __exist := -2;
    END IF;

    IF __exist = 1 THEN
        RETURN (SELECT user_access_id AS user_access_id FROM cliente WHERE cliente_id = _cliente_id);
    ELSE
        RETURN __return;
    END IF;
END;
$$;
alter function fn_cliente_conseguir_user_access_id(integer) owner to postgres;

SELECT * FROM fn_cliente_conseguir_mid(3)
create or replace function fn_cliente_conseguir_mid(_cliente_id integer) returns uuid
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_cliente_conseguir_mid
OBJETIVO:
RETORNA:
******************************************************************************/
DECLARE
    __exist  integer := 1;
    __return uuid := uuid_nil();
BEGIN
    IF (select exists(select 1 from cliente where cliente_id = _cliente_id)) THEN
        __exist := 1;
    ELSE
        __exist := -2;
    END IF;

    IF __exist = 1 THEN
        RETURN (SELECT mid AS mid
                FROM user_access
                WHERE user_access_id = fn_personal_conseguir_user_access_id(_cliente_id));
    ELSE
        RETURN __return;
    END IF;
END;
$$;
alter function fn_cliente_conseguir_mid(integer) owner to postgres;



-- ----------------------------------------------------------------------------------- --
create or replace function fn_cliente_obtener_listado()
    returns TABLE
            (
                cliente_id      integer,
                user_access_id  integer,
                sucursal_id     integer,
                nombre          character varying,
                apellidos       character varying,
                correo          character varying,
                tel_1           character varying,
                c_credito       boolean,
                c_ahorro        boolean,
                fh_registro     timestamptz,
                fh_modificacion timestamptz,
                fh_autorizacion timestamptz,
                usr_registra_id integer,
                usr_modifica_id integer,
                usr_autoriza_id integer
--                 total_count     bigint
            )
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_cliente_obtener_listado
OBJETIVO:
RETORNA:
******************************************************************************/
DECLARE
    __record record;
    __query  text;
BEGIN
    __query := 'SELECT * FROM vw_cliente ORDER BY cliente_id DESC';

    FOR __record IN EXECUTE __query
        LOOP
            cliente_id := __record.cliente_id;
            user_access_id := __record.user_access_id;
            sucursal_id := __record.sucursal_id;
            nombre := __record.nombre;
            apellidos := __record.apellidos;
            correo := __record.correo;
            tel_1 := __record.tel_1;
            c_credito := __record.c_credito;
            c_ahorro := __record.c_ahorro;
            fh_registro := __record.fh_registro;
            fh_modificacion := __record.fh_modificacion;
            fh_autorizacion := __record.fh_autorizacion;
            usr_registra_id := __record.usr_registra_id;
            usr_modifica_id := __record.usr_modifica_id;
            usr_autoriza_id := __record.usr_autoriza_id;
            RETURN NEXT;
        END LOOP;
END;
$$;
alter function fn_cliente_obtener_listado() owner to postgres;


-- ----------------------------------------------------------------------------------- --
create or replace function fn_cliente_obtener_ultimo_id()
    RETURNS integer
    language plpgsql
AS
$$
/******************************************************************************
NOMBRE: fn_cliente_obtener_ultimo_id
OBJETIVO:
******************************************************************************/
DECLARE
BEGIN
    RETURN (SELECT cliente_id AS cliente_id FROM cliente ORDER BY cliente_id DESC LIMIT 1);
END
$$;
alter function fn_cliente_obtener_ultimo_id() owner to postgres;


-- ----------------------------------------------------------------------------------- --
create or replace function fn_cliente_eliminar_id(_cliente_id integer) returns integer
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_cliente_eliminar_id
OBJETIVO:
RETORNA:
******************************************************************************/
DECLARE
    __RW     integer;
    __return integer := -1;
BEGIN

    DELETE FROM cliente WHERE cliente_id = _cliente_id;
    GET DIAGNOSTICS __RW = ROW_COUNT;

    IF __RW = 1 THEN --- Se obtuvo éxito al actualizar.
        __return := 1;
    ELSE
        __return := -2;
    END IF;

    RETURN __return;
END;
$$;
alter function fn_cliente_eliminar_id(integer) owner to postgres;


-- ----------------------------------------------------------------------------------- --
create or replace function fn_transaccion_insertar(
    _transaction_id integer, _folio integer, _cliente_id integer, _sucursal_id integer, _fh_registro timestamptz,
    _fh_modificacion timestamptz, _usr_registra_id integer, _usr_modifica_id integer
) returns integer
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_transaccion_insertar
OBJETIVO:
RETORNA:
******************************************************************************/
DECLARE
    __RW                 integer;
    __tmp_transaction_id transaction.transaction_id%TYPE;
    __return             integer := -1;
BEGIN

    INSERT INTO transaction(transaction_id, folio, cliente_id, sucursal_id, fh_registro,
                            fh_modificacion, usr_registra_id, usr_modifica_id)
    VALUES (_transaction_id, _folio, _cliente_id, _sucursal_id, _fh_registro,
            _fh_modificacion, _usr_registra_id, _usr_modifica_id);

    GET DIAGNOSTICS __RW = ROW_COUNT;

    IF __RW = 1 THEN
        __tmp_transaction_id = (SELECT nextval('transaction_id_seq'));

        __return := __tmp_transaction_id;
    ELSE
        __return := -1;
    END IF;

    RETURN __return;
END
$$;
alter function fn_transaccion_insertar(
    integer, integer, integer, integer, timestamptz, timestamptz, integer, integer
    ) owner to postgres;


-- ----------------------------------------------------------------------------------- --
create or replace function fn_transaccion_actualizar(
    _transaction_id integer, _folio integer, _cliente_id integer, _sucursal_id integer, _fh_registro timestamptz,
    _fh_modificacion timestamptz, _usr_registra_id integer, _usr_modifica_id integer
) returns integer
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_transaccion_actualizar
OBJETIVO:
RETORNA:
******************************************************************************/
DECLARE
    __RW     integer;
    __return integer := -1;
BEGIN

    UPDATE transaction
    SET folio=_folio,
        cliente_id=_cliente_id,
        sucursal_id=_sucursal_id,
        fh_registro=_fh_registro,
        fh_modificacion =_fh_modificacion,
        usr_registra_id=_usr_registra_id,
        usr_modifica_id =_usr_modifica_id
    WHERE transaction_id = _transaction_id;

    GET DIAGNOSTICS __RW = ROW_COUNT;

    IF __RW = 1 THEN --- Se obtuvo éxito al actualizar.
        __return := 1;
    ELSE
        __return := -2;
    END IF;

    RETURN __return;
END
$$;
alter function fn_transaccion_actualizar(
    integer, integer, integer, integer, timestamptz, timestamptz, integer, integer
    ) owner to postgres;

-- ----------------------------------------------------------------------------------- --
create or replace function fn_transaccion_obtener_id(_transaction_id integer)
    returns SETOF vw_transaccion
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_transaccion_obtener_id
OBJETIVO:
RETORNA:
******************************************************************************/
DECLARE
    __record vw_transaccion;
BEGIN
    FOR __record IN SELECT * FROM vw_transaccion WHERE transaction_id = _transaction_id
        LOOP
            RETURN NEXT __record;
        END LOOP;
END;
$$;
alter function fn_transaccion_obtener_id(integer) owner to postgres;

-- ----------------------------------------------------------------------------------- --
create or replace function fn_transaccion_obtener_listado()
    returns TABLE
            (
                transaction_id  integer,
                folio           integer,
                cliente_id      integer,
                sucursal_id     integer,
                fh_registro     timestamptz,
                fh_modificacion timestamptz,
                usr_registra_id integer,
                usr_registra    character varying,
                usr_modifica_id integer,
                usr_modifica    character varying,
                total_count     bigint
            )
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_transaccion_obtener_listado
OBJETIVO:
RETORNA:
******************************************************************************/
DECLARE
    __record record;
    __query  text;
BEGIN

    __query := 'SELECT * ,COUNT(transaction_id) OVER() AS total_count FROM vw_transaccion ORDER BY transaction_id DESC';

    FOR __record IN EXECUTE __query
        LOOP
            transaction_id := __record.transaction_id;
            folio := __record.folio;
            cliente_id := __record.cliente_id;
            sucursal_id := __record.sucursal_id;
            fh_registro := __record.fh_registro;
            fh_modificacion := __record.fh_modificacion;
            usr_registra_id := __record.usr_registra_id;
            usr_registra := __record.usr_registra;
            usr_modifica_id := __record.usr_modifica_id;
            usr_modifica := __record.usr_modifica;
            total_count := __record.total_count;
            RETURN NEXT;
        END LOOP;
END;
$$;
alter function fn_transaccion_obtener_listado() owner to postgres;


-- ----------------------------------------------------------------------------------- --
create or replace function fn_transaccion_obtener_ultimo_id()
    RETURNS integer
    language plpgsql
AS
$$
/******************************************************************************
NOMBRE: fn_transaccion_obtener_ultimo_id
OBJETIVO:
******************************************************************************/
DECLARE
BEGIN
    RETURN (SELECT transaction_id AS transaction_id FROM transaction ORDER BY transaction_id DESC LIMIT 1);
END
$$;
alter function fn_transaccion_obtener_ultimo_id() owner to postgres;


-- ----------------------------------------------------------------------------------- --
create or replace function fn_transaccion_eliminar_id(_transaction_id integer) returns integer
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_transaccion_eliminar_id
OBJETIVO:
RETORNA:
******************************************************************************/
DECLARE
    __RW     integer;
    __return integer := -1;
BEGIN
    DELETE FROM transaction WHERE transaction_id = _transaction_id;
    GET DIAGNOSTICS __RW = ROW_COUNT;

    IF __RW = 1 THEN --- Se obtuvo éxito al actualizar.
        __return := 1;
    ELSE
        __return := -2;
    END IF;

    RETURN __return;
END;
$$;
alter function fn_transaccion_eliminar_id(integer) owner to postgres;



-- ----------------------------------------------------------------------------------- --
create or replace function fn_transaction_credit_insertar(
    _credit_id integer, _transaction_id integer, _documento_id integer, _cobrado numeric, _por_cobrar numeric,
    _total numeric, _status_id integer
) returns integer
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_transaction_credit_insertar
OBJETIVO:
RETORNA:
******************************************************************************/
DECLARE
    __RW            integer;
    __tmp_credit_id transaction_credit.credit_id%TYPE;
    __return        integer := -1;
BEGIN

    INSERT INTO transaction_credit(credit_id, transaction_id, documento_id, cobrado, por_cobrar, total, status_id)
    VALUES (_credit_id, _transaction_id, _documento_id, _cobrado, _por_cobrar, _total, _status_id);

    GET DIAGNOSTICS __RW = ROW_COUNT;

    IF __RW = 1 THEN
        __tmp_credit_id = (SELECT nextval('transaction_credit_id_seq'));

        __return := __tmp_credit_id;
    ELSE
        __return := -1;
    END IF;

    RETURN __return;
END
$$;
alter function fn_transaction_credit_insertar(
    integer, integer, integer, numeric, numeric, numeric, integer
    ) owner to postgres;


-- ----------------------------------------------------------------------------------- --
create or replace function fn_transaction_credit_actualizar(
    _credit_id integer, _transaction_id integer, _documento_id integer, _cobrado numeric, _por_cobrar numeric,
    _total numeric, _status_id integer
) returns integer
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_transaction_credit_actualizar
OBJETIVO:
RETORNA:
******************************************************************************/
DECLARE
    __RW     integer;
    __return integer := -1;
BEGIN

    UPDATE transaction_credit
    SET transaction_id=_transaction_id,
        documento_id=_documento_id,
        cobrado       =_cobrado,
        por_cobrar=_por_cobrar,
        total         =_total,
        status_id     =_status_id
    WHERE credit_id = _credit_id;

    GET DIAGNOSTICS __RW = ROW_COUNT;

    IF __RW = 1 THEN --- Se obtuvo éxito al actualizar.
        __return := 1;
    ELSE
        __return := -2;
    END IF;

    RETURN __return;
END
$$;
alter function fn_transaction_credit_actualizar(
    integer, integer, integer, numeric, numeric, numeric, integer
    ) owner to postgres;


-- ----------------------------------------------------------------------------------- --
create or replace function fn_transaction_credit_obtener_id(_credit_id integer)
    returns SETOF vw_transaccion_credito
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_transaction_credit_obtener_id
OBJETIVO:
RETORNA:
******************************************************************************/
DECLARE
    __record vw_transaccion_credito;
BEGIN
    FOR __record IN SELECT * FROM vw_transaccion_credito WHERE credit_id = _credit_id
        LOOP
            RETURN NEXT __record;
        END LOOP;
END;
$$;
alter function fn_transaction_credit_obtener_id(integer) owner to postgres;


-- ----------------------------------------------------------------------------------- --
create or replace function fn_transaction_credit_obtener_listado()
    returns TABLE
            (
                credit_id       integer,
                transaction_id  integer,
                documento_id    integer,
                documento_txt   character varying,
                nombre_sucursal character varying,
                cobrado         numeric,
                por_cobrar      numeric,
                cobrado_txt     character varying,
                total           numeric,
                fh_registro     timestamptz,
                fh_modificacion timestamptz,
                usr_registra_id integer,
                usr_registra    character varying,
                usr_modifica_id integer,
                usr_modifica    character varying,
                total_count     bigint
            )
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_transaction_credit_obtener_listado
OBJETIVO:
RETORNA:
******************************************************************************/
DECLARE
    __record record;
    __query  text;
BEGIN

    __query := 'SELECT * ,COUNT(credit_id) OVER() AS total_count FROM vw_transaccion_credito ORDER BY credit_id DESC';

    FOR __record IN EXECUTE __query
        LOOP
            credit_id := __record.credit_id;
            transaction_id := __record.transaction_id;
            documento_id := __record.documento_id;
            documento_txt := __record.documento_txt;
            nombre_sucursal := __record.nombre_sucursal;
            cobrado := __record.cobrado;
            por_cobrar := __record.por_cobrar;
            cobrado_txt := __record.cobrado_txt;
            total := __record.total;
            fh_registro := __record.fh_registro;
            fh_modificacion := __record.fh_modificacion;
            usr_registra_id := __record.usr_registra_id;
            usr_registra := __record.usr_registra;
            usr_modifica_id := __record.usr_modifica_id;
            usr_modifica := __record.usr_modifica;
            total_count := __record.total_count;
            RETURN NEXT;
        END LOOP;
END;
$$;
alter function fn_transaction_credit_obtener_listado() owner to postgres;


-- ----------------------------------------------------------------------------------- --
create or replace function fn_transaction_credit_obtener_ultimo_id()
    RETURNS integer
    language plpgsql
AS
$$
/******************************************************************************
NOMBRE: fn_transaction_credit_obtener_ultimo_id
OBJETIVO:
******************************************************************************/
DECLARE
BEGIN
    RETURN (SELECT credit_id AS credit_id FROM transaction_credit ORDER BY credit_id DESC LIMIT 1);
END
$$;
alter function fn_transaction_credit_obtener_ultimo_id() owner to postgres;


-- ----------------------------------------------------------------------------------- --
create or replace function fn_transaction_credit_eliminar_id(_credit_id integer) returns integer
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_transaction_credit_eliminar_id
OBJETIVO:
RETORNA:
******************************************************************************/
DECLARE
    __RW     integer;
    __return integer := -1;
BEGIN
    DELETE FROM transaction_credit WHERE credit_id = _credit_id;
    GET DIAGNOSTICS __RW = ROW_COUNT;

    IF __RW = 1 THEN --- Se obtuvo éxito al actualizar.
        __return := 1;
    ELSE
        __return := -2;
    END IF;

    RETURN __return;
END;
$$;
alter function fn_transaction_credit_eliminar_id(integer) owner to postgres;



-- ----------------------------------------------------------------------------------- --
create or replace function fn_transaction_saving_insertar(
    _saving_id integer, _transaction_id integer, _documento_id integer, _cantidad numeric, _total numeric
) returns integer
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_transaction_saving_insertar
OBJETIVO:
RETORNA:
******************************************************************************/
DECLARE
    __RW            integer;
    __tmp_saving_id transaction_saving.saving_id%TYPE;
    __return        integer := -1;
BEGIN

    INSERT INTO transaction_saving(saving_id, transaction_id, documento_id, cantidad, total)
    VALUES (_saving_id, _transaction_id, _documento_id, _cantidad, _total);

    GET DIAGNOSTICS __RW = ROW_COUNT;

    IF __RW = 1 THEN
        __tmp_saving_id = (SELECT nextval('transaction_saving_id_seq'));

        __return := __tmp_saving_id;
    ELSE
        __return := -1;
    END IF;

    RETURN __return;
END
$$;
alter function fn_transaction_saving_insertar(
    integer, integer, integer, numeric, numeric
    ) owner to postgres;


-- ----------------------------------------------------------------------------------- --
create or replace function fn_transaction_saving_actualizar(
    _saving_id integer, _transaction_id integer, _documento_id integer, _cantidad numeric, _total numeric
) returns integer
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_transaction_saving_actualizar
OBJETIVO:
RETORNA:
******************************************************************************/
DECLARE
    __RW     integer;
    __return integer := -1;
BEGIN

    UPDATE transaction_saving
    SET transaction_id =_transaction_id,
        documento_id=_documento_id,
        cantidad=_cantidad,
        total          =_total
    WHERE saving_id = _saving_id;

    GET DIAGNOSTICS __RW = ROW_COUNT;

    IF __RW = 1 THEN --- Se obtuvo éxito al actualizar.
        __return := 1;
    ELSE
        __return := -2;
    END IF;

    RETURN __return;
END
$$;
alter function fn_transaction_saving_actualizar(
    integer, integer, integer, numeric, numeric
    ) owner to postgres;


-- ----------------------------------------------------------------------------------- --
create or replace function fn_transaction_saving_obtener_id(_saving_id integer)
    returns SETOF vw_transaccion_ahorro
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_transaction_saving_obtener_id
OBJETIVO:
RETORNA:
******************************************************************************/
DECLARE
    __record vw_transaccion_ahorro;
BEGIN
    FOR __record IN SELECT * FROM vw_transaccion_ahorro WHERE saving_id = _saving_id
        LOOP
            RETURN NEXT __record;
        END LOOP;
END;
$$;
alter function fn_transaction_saving_obtener_id(integer) owner to postgres;


-- ----------------------------------------------------------------------------------- --
create or replace function fn_transaction_saving_obtener_listado()
    returns TABLE
            (
                saving_id       integer,
                transaction_id  integer,
                documento_id    integer,
                documento_txt   character varying,
                nombre_sucursal character varying,
                cantidad        numeric,
                total           numeric,
                fh_registro     timestamptz,
                fh_modificacion timestamptz,
                usr_registra_id integer,
                usr_registra    character varying,
                usr_modifica_id integer,
                usr_modifica    character varying,
                total_count     bigint
            )
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_transaction_saving_obtener_listado
OBJETIVO:
RETORNA:
******************************************************************************/
DECLARE
    __record record;
    __query  text;
BEGIN

    __query := 'SELECT * ,COUNT(saving_id) OVER() AS total_count FROM vw_transaccion_ahorro ORDER BY saving_id DESC';

    FOR __record IN EXECUTE __query
        LOOP
            saving_id := __record.saving_id;
            transaction_id := __record.transaction_id;
            documento_id := __record.documento_id;
            documento_txt := __record.documento_txt;
            nombre_sucursal := __record.nombre_sucursal;
            cantidad := __record.cantidad;
            total := __record.total;
            fh_registro := __record.fh_registro;
            fh_modificacion := __record.fh_modificacion;
            usr_registra_id := __record.usr_registra_id;
            usr_registra := __record.usr_registra;
            usr_modifica_id := __record.usr_modifica_id;
            usr_modifica := __record.usr_modifica;
            total_count := __record.total_count;
            RETURN NEXT;
        END LOOP;
END;
$$;
alter function fn_transaction_saving_obtener_listado() owner to postgres;



-- ----------------------------------------------------------------------------------- --
create or replace function fn_transaction_saving_obtener_ultimo_id()
    RETURNS integer
    language plpgsql
AS
$$
/******************************************************************************
NOMBRE: fn_transaction_saving_obtener_ultimo_id
OBJETIVO:
******************************************************************************/
DECLARE
BEGIN
    RETURN (SELECT saving_id AS saving_id FROM transaction_saving ORDER BY saving_id DESC LIMIT 1);
END
$$;
alter function fn_transaction_saving_obtener_ultimo_id() owner to postgres;



-- ----------------------------------------------------------------------------------- --
create or replace function fn_transaction_saving_eliminar_id(_saving_id integer) returns integer
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_transaction_saving_eliminar_id
OBJETIVO:
RETORNA:
******************************************************************************/
DECLARE
    __RW     integer;
    __return integer := -1;
BEGIN
    DELETE FROM transaction_saving WHERE saving_id = _saving_id;
    GET DIAGNOSTICS __RW = ROW_COUNT;

    IF __RW = 1 THEN --- Se obtuvo éxito al actualizar.
        __return := 1;
    ELSE
        __return := -2;
    END IF;

    RETURN __return;
END;
$$;
alter function fn_transaction_saving_eliminar_id(integer) owner to postgres;



-- ----------------------------------------------------------------------------------- --
create or replace function fn_tower_insertar(
    _tower_id integer, _role_id integer, _usuario_id integer, _mid uuid, _auth character varying,
    _pass character varying, _is_staff integer, _fh_registro timestamptz, _fh_modificacion timestamptz,
    _usr_registra_id integer, _usr_modifica_id integer
) returns integer
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_tower_insertar
OBJETIVO:
RETORNA:
******************************************************************************/
DECLARE
    __RW           integer;
    __tmp_tower_id tower.tower_id%TYPE;
    __return       integer := -1;
BEGIN

    INSERT INTO tower(tower_id, role_id, usuario_id, mid, auth, pass, is_staff,
                      fh_registro, fh_modificacion, usr_registra_id, usr_modifica_id)
    VALUES (_tower_id, _role_id, _usuario_id, _mid, _auth, _pass, _is_staff, _fh_registro,
            _fh_modificacion, _usr_registra_id, _usr_modifica_id);

    GET DIAGNOSTICS __RW = ROW_COUNT;

    IF __RW = 1 THEN
        __tmp_tower_id = (SELECT nextval('tower_id_seq'));

        __return := __tmp_tower_id;
    ELSE
        __return := -1;
    END IF;

    RETURN __return;
END
$$;
alter function fn_tower_insertar(
    integer, integer, integer, uuid, character varying,
    character varying, integer, timestamptz, timestamptz, integer, integer
    ) owner to postgres;


-- ----------------------------------------------------------------------------------- --
create or replace function fn_tower_actualizar(
    _tower_id integer, _role_id integer, _usuario_id integer, _mid uuid, _auth character varying,
    _pass character varying, _is_staff integer, _fh_registro timestamptz, _fh_modificacion timestamptz,
    _usr_registra_id integer, _usr_modifica_id integer
) returns integer
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_tower_actualizar
OBJETIVO:
RETORNA:
******************************************************************************/
DECLARE
    __RW     integer;
    __return integer := -1;
BEGIN

    UPDATE transaction_saving
    SET role_id         =_role_id,
        usuario_id=_usuario_id,
        mid=_mid,
        auth=_auth,
        pass            =_pass,
        is_staff=_is_staff,
        fh_registro=_fh_registro,
        fh_modificacion=_fh_modificacion,
        usr_registra_id =_usr_registra_id,
        usr_modifica_id= _usr_modifica_id
    WHERE tower_id = _tower_id;

    GET DIAGNOSTICS __RW = ROW_COUNT;

    IF __RW = 1 THEN --- Se obtuvo éxito al actualizar.
        __return := 1;
    ELSE
        __return := -2;
    END IF;

    RETURN __return;
END
$$;
alter function fn_tower_actualizar(
    integer, integer, integer, uuid, character varying,
    character varying, integer, timestamptz, timestamptz, integer, integer
    ) owner to postgres;


-- ----------------------------------------------------------------------------------- --
create or replace function fn_tower_obtener_id(_tower_id integer)
    returns SETOF vw_tower
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_tower_obtener_id
OBJETIVO:
RETORNA:
******************************************************************************/
DECLARE
    __record vw_tower;
BEGIN
    FOR __record IN SELECT * FROM vw_tower WHERE tower_id = _tower_id
        LOOP
            RETURN NEXT __record;
        END LOOP;
END;
$$;
alter function fn_tower_obtener_id(integer) owner to postgres;


-- ----------------------------------------------------------------------------------- --
create or replace function fn_tower_obtener_listado()
    returns TABLE
            (
                tower_id        integer,
                role_id         integer,
                usuario_id      integer,
                mid             uuid,
                auth            character varying,
                pass            character varying,
                is_staff        integer,
                fh_registro     timestamptz,
                fh_modificacion timestamptz,
                usr_registra_id integer,
                usr_modifica_id integer
            )
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_tower_obtener_listado
OBJETIVO:
RETORNA:
******************************************************************************/
DECLARE
    __record record;
    __query  text;
BEGIN

    __query := 'SELECT * FROM vw_tower ORDER BY tower_id DESC';

    FOR __record IN EXECUTE __query
        LOOP
            tower_id := __record.tower_id;
            role_id := __record.role_id;
            usuario_id := __record.usuario_id;
            mid := __record.mid;
            auth := __record.auth;
            pass := __record.pass;
            is_staff := __record.is_staff;
            fh_registro := __record.fh_registro;
            fh_modificacion := __record.fh_modificacion;
            usr_registra_id := __record.usr_registra_id;
            usr_modifica_id := __record.usr_modifica_id;
            RETURN NEXT;
        END LOOP;
END;
$$;
alter function fn_tower_obtener_listado() owner to postgres;


-- ----------------------------------------------------------------------------------- --
create or replace function fn_tower_obtener_ultimo_id()
    RETURNS integer
    language plpgsql
AS
$$
/******************************************************************************
NOMBRE: fn_tower_obtener_ultimo_id
OBJETIVO:
******************************************************************************/
DECLARE
BEGIN
    RETURN (SELECT tower_id AS tower_id FROM tower ORDER BY tower_id DESC LIMIT 1);
END
$$;
alter function fn_tower_obtener_ultimo_id() owner to postgres;


-- ----------------------------------------------------------------------------------- --
create or replace function fn_tower_eliminar_id(_tower_id integer) returns integer
    language plpgsql
as
$$
/******************************************************************************
NOMBRE: fn_tower_eliminar_id
OBJETIVO:
RETORNA:
******************************************************************************/
DECLARE
    __RW     integer;
    __return integer := -1;
BEGIN
    DELETE FROM tower WHERE tower_id = _tower_id;
    GET DIAGNOSTICS __RW = ROW_COUNT;

    IF __RW = 1 THEN --- Se obtuvo éxito al actualizar.
        __return := 1;
    ELSE
        __return := -2;
    END IF;

    RETURN __return;
END;
$$;
alter function fn_tower_eliminar_id(integer) owner to postgres;