
/* TableNameVariable */

set @tableNameQuoted = concat('`', @tablePrefix, 'PaymentSaga`');
set @tableNameNonQuoted = concat(@tablePrefix, 'PaymentSaga');


/* DropTable */

set @dropTable = concat('drop table if exists ', @tableNameQuoted);
prepare script from @dropTable;
execute script;
deallocate prepare script;
