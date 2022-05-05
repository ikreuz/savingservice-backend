-- --
-- --
-- --
INSERT INTO roles(role_id, role_name)
VALUES (1, 'Master');

INSERT INTO roles(role_id, role_name)
VALUES (2, 'Capturista');

INSERT INTO roles(role_id, role_name)
VALUES (3, 'Cliente');

-- --
-- --
-- --
INSERT INTO usuario(usuario_id, nombre, apellidos, correo, nombre_usuario, fh_registro, fh_modificacion,
                    usr_registra_id, usr_modifica_id)
VALUES (1, 'Camina', 'Drummer', 'drummer.app@fake.com', 'drummer', NOW()::timestamptz,
        CURRENT_TIMESTAMP, 1, 0);

INSERT INTO usuario(usuario_id, nombre, apellidos, correo, nombre_usuario, fh_registro, fh_modificacion,
                    usr_registra_id, usr_modifica_id)
VALUES (2, 'James', 'Dean', 'dean.app@fake.com', 'dean', NOW()::timestamptz,
        CURRENT_TIMESTAMP, 1, 0);

INSERT INTO usuario(usuario_id, nombre, apellidos, correo, nombre_usuario, fh_registro, fh_modificacion,
                    usr_registra_id, usr_modifica_id)
VALUES (3, 'Diana', 'Kurkova', 'diana.app@fake.com', 'diana', NOW()::timestamptz,
        CURRENT_TIMESTAMP, 1, 0);



INSERT INTO tower(tower_id, role_id, usuario_id, mid, auth, pass, is_staff, fh_registro,
                  fh_modificacion, usr_registra_id, usr_modifica_id)
VALUES (1, 1, 1, '67e276d4-7d6c-8330-c823-7d62ccd35a95', '00xyZfb/XlxROoNOz2AOXjw+cT/+YJfI8nAZ7t6Z7ew=',
        'wQskObIJVpTiMXiiDkbmAw==', 1, NOW()::TIMESTAMP, CURRENT_TIMESTAMP, 1, 0);

INSERT INTO tower(tower_id, role_id, usuario_id, mid, auth, pass, is_staff, fh_registro,
                  fh_modificacion, usr_registra_id, usr_modifica_id)
VALUES (2, 2, 2, '4c6e6b25-a2fe-6041-df62-b8e28533b5ab', '00c9mMkz/n50VYQUyvEAzEdW+1o1Fk9FALeZhnQy7LM=',
        'wQskObIJVpTiMXiiDkbmAw==', 1, NOW()::TIMESTAMP, CURRENT_TIMESTAMP, 1, 0);

INSERT INTO tower(tower_id, role_id, usuario_id, mid, auth, pass, is_staff, fh_registro,
                  fh_modificacion, usr_registra_id, usr_modifica_id)
VALUES (3, 3, 3, '6ca64aa5-9e56-b0e1-21a5-148ae4fae03f', '00qBdp3bUt0TyupDiCJuA7iIhPJMRCS5C78qoIK09vo=',
        'wQskObIJVpTiMXiiDkbmAw==', 1, NOW()::TIMESTAMP, CURRENT_TIMESTAMP, 1, 0);
-- --
-- --
-- --
INSERT INTO user_access(user_access_id, usuario_id, mid, auth, created_at, last_login, activity_status, is_staff,
                        operation_id, operation_context_id, fh_registro, fh_modificacion, fh_activacion,
                        usr_registra_id, usr_modifica_id, usr_activa_id)
VALUES (1, 1, '67e276d4-7d6c-8330-c823-7d62ccd35a95', '00xyZfb/XlxROoNOz2AOXjw+cT/+YJfI8nAZ7t6Z7ew=',
        NOW()::timestamptz, NOW()::timestamptz, false, 1, 1542, 1562, NOW()::timestamptz, NOW()::timestamptz,
        NOW()::timestamptz,
        1, 1, 0);

INSERT INTO user_access(user_access_id, usuario_id, mid, auth, created_at, last_login, activity_status, is_staff,
                        operation_id, operation_context_id, fh_registro, fh_modificacion, fh_activacion,
                        usr_registra_id, usr_modifica_id, usr_activa_id)
VALUES (2, 2, '4c6e6b25-a2fe-6041-df62-b8e28533b5ab', '00c9mMkz/n50VYQUyvEAzEdW+1o1Fk9FALeZhnQy7LM=',
        NOW()::timestamptz, NOW()::timestamptz, false, 1, 1542, 1562, NOW()::timestamptz, NOW()::timestamptz,
        NOW()::timestamptz,
        1, 1, 0);

INSERT INTO user_access(user_access_id, usuario_id, mid, auth, created_at, last_login, activity_status, is_staff,
                        operation_id, operation_context_id, fh_registro, fh_modificacion, fh_activacion,
                        usr_registra_id, usr_modifica_id, usr_activa_id)
VALUES (3, 3, '6ca64aa5-9e56-b0e1-21a5-148ae4fae03f', '00qBdp3bUt0TyupDiCJuA7iIhPJMRCS5C78qoIK09vo=',
        NOW()::timestamptz, NOW()::timestamptz, false, 2, 1542, 1562, NOW()::timestamptz, NOW()::timestamptz,
        NOW()::timestamptz,
        1, 1, 0);

-- --
-- --
-- --
INSERT INTO personal(personal_id, user_access_id, apellidos, nombre, sucursal_id, funcion_id,
                     fh_registro, fh_autorizacion, fh_modificacion, usr_registra_id, usr_autoriza_id, usr_modifica_id)
VALUES (1, 1, 'Camina', 'Drummer', 1, 39, NOW()::timestamptz, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, 1, 0, 0);

INSERT INTO personal(personal_id, user_access_id, apellidos, nombre, sucursal_id, funcion_id,
                     fh_registro, fh_autorizacion, fh_modificacion, usr_registra_id, usr_autoriza_id, usr_modifica_id)
VALUES (2, 2, 'James', 'Dean', 1, 40, NOW()::timestamptz, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, 1, 0, 0);

-- --
-- --
-- --
INSERT INTO cliente(cliente_id, user_access_id, sucursal_id, nombre, apellidos, correo, tel_1, c_credito, c_ahorro,
                    fh_registro, fh_modificacion, fh_autorizacion, usr_registra_id, usr_modifica_id, usr_autoriza_id)
VALUES (1, 3, 1, 'Diana', 'Natasha', '', '', false, false, NOW()::timestamptz, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, 1,
        0, 0);



-- --
-- --
-- --
INSERT INTO transaction(transaction_id, folio, cliente_id, sucursal_id, fh_registro, fh_modificacion,
                        usr_registra_id, usr_modifica_id)
VALUES (1, 1, 1, 1, NOW()::timestamptz, CURRENT_TIMESTAMP, 1, 0);
-- doc 52 cierre, 53 apertura, 54 deposito, 55 retiro
-- spend 0, by spend 6000, balance 6000
-- status 47 borrador, 48 por cobrar, 49 cobrado, 50 cancelada
INSERT INTO transaction_credit(credit_id, transaction_id, documento_id, cobrado, por_cobrar, total, status_id)
VALUES (1, 1, 53, 0, 6000, 6000, 47);

INSERT INTO transaction_credit(credit_id, transaction_id, documento_id, cobrado, por_cobrar, total, status_id)
VALUES (2, 1, 54, 3000, 3000, 6000, 48);

INSERT INTO transaction_credit(credit_id, transaction_id, documento_id, cobrado, por_cobrar, total, status_id)
VALUES (3, 1, 54, 3000, 3000, 6000, 48);

INSERT INTO transaction_credit(credit_id, transaction_id, documento_id, cobrado, por_cobrar, total, status_id)
VALUES (4, 1, 52, 3000, 0, 6000, 49);


-- --
-- --
-- --
INSERT INTO transaction(transaction_id, folio, cliente_id, sucursal_id, fh_registro,
                        fh_modificacion, usr_registra_id, usr_modifica_id)
VALUES (2, 2, 1, 1, NOW()::timestamptz, CURRENT_TIMESTAMP, 1, 0);
-- doc 52 cierre, 53 apertura, 54 deposito, 55 retiro
-- spend 0, by spend 6000, balance 6000
-- status 47 borrador, 48 por cobrar, 49 cobrado, 50 cancelada
INSERT INTO transaction_saving(saving_id, transaction_id, documento_id, cantidad, total)
VALUES (1, 2, 53, 400, 400);

INSERT INTO transaction_saving(saving_id, transaction_id, documento_id, cantidad, total)
VALUES (2, 2, 54, 2400, 2800);

INSERT INTO transaction_saving(saving_id, transaction_id, documento_id, cantidad, total)
VALUES (3, 2, 55, 2800, 0);

INSERT INTO transaction_saving(saving_id, transaction_id, documento_id, cantidad, total)
VALUES (4, 2, 52, 0, 0);



INSERT INTO sucursal (sucursal_id, sucursal_status, sucursal_cancelada, residencia_fiscal_id,
                      entidad_id, nombre_sucursal, abr_sucursal, direccion, telefono, cuentas_correo, fh_registro,
                      fh_modificacion, fh_cancelacion, fh_activacion, usr_registra_id, usr_modifica_id,
                      usr_cancela_id, usr_activa_id)
VALUES (1, false, false, 4003, 17, 'Guadalajara', 'JAL', 'Division del Norte', '123456789', 'saving.app@fake.com ',
        NOW()::timestamptz, NOW()::timestamptz, NOW()::timestamptz, NOW()::timestamptz, 1, 0, 0, 0);



INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (1, 'Raíz', 1, 1);
-- ----------------------------------------------------------------------------------------- /* */
-- ----------------------------------------------------------------------------------------- /* CAT ENTIDADES FEDERATIVAS */
-- ----------------------------------------------------------------------------------------- /* 2 - 34 */

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (2, 'Cat. Entidades Federativas', 1, 2);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (2, 'Aguascalientes', 1, 3);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (2, 'Baja California Norte', 2, 4);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (2, 'Baja California Sur', 3, 5);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (2, 'Campeche', 4, 6);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (2, 'Chiapas', 5, 7);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (2, 'Chihuahua', 6, 8);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (2, 'Coahuila', 7, 9);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (2, 'Colima', 8, 10);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (2, 'México', 9, 11);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (2, 'Durango', 10, 12);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (2, 'Estado de México', 11, 13);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (2, 'Guanajuato', 12, 14);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (2, 'Guerrero', 13, 15);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (2, 'Hidalgo', 14, 16);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (2, 'Jalisco', 15, 17);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (2, 'Michoacán', 16, 18);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (2, 'Morelos', 17, 19);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (2, 'Nayarit', 18, 20);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (2, 'Nuevo Leon', 19, 21);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (2, 'Oaxaca', 20, 22);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (2, 'Puebla', 21, 23);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (2, 'Queretaro', 22, 24);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (2, 'Quintana Roo', 23, 25);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (2, 'San Luis Potosi', 24, 26);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (2, 'Sinaloa', 25, 27);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (2, 'Sonora', 26, 28);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (2, 'Tabasco', 27, 29);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (2, 'Tamaulipas', 28, 30);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (2, 'Tlaxcala', 29, 31);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (2, 'Veracruz', 30, 32);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (2, 'Yucatán', 31, 33);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (2, 'Zacatecas', 32, 34);



INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (1, 'Cat. Cuentas', 1, 35);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (35, 'Crédito', 1, 36);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (35, 'Ahorro', 2, 37);



INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (1, 'Cat. Funciones del Personal', 1, 38);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (38, 'Master', 1, 39);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (38, 'Capturista', 2, 40);



INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (1, 'Cat. Operaciones Usuario', 1, 41);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (41, 'Crear', 1, 42);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (41, 'Cobrar', 2, 43);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (41, 'Cerrar', 3, 44);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (41, 'Cancelar', 4, 45);



INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (1, 'Cat. Transacción', 1, 46);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (46, 'Borrador', 1, 47);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (46, 'Por cobrar', 2, 48);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (46, 'Cobrada', 3, 49);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (46, 'Cancelada', 4, 50);



INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (1, 'Cat. Documento', 1, 51);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (51, 'Cierre', 1, 52);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (51, 'Apertura', 2, 53);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (51, 'Deposito', 3, 54);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (51, 'Retiro', 4, 55);



INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (1, 'Cat. Gestión de operaciones de identidad', 1, 56);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (56, 'Añadir', 1, 57);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (56, 'Crear', 2, 58);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (56, 'Asignar', 4, 59);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (56, 'Quitar', 5, 60);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (56, 'Activar', 6, 61);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (56, 'Suspender', 7, 62);

INSERT INTO conceptos (cnpto_padre_id, concepto, orden, concepto_id)
VALUES (56, 'Eliminar', 8, 63);

