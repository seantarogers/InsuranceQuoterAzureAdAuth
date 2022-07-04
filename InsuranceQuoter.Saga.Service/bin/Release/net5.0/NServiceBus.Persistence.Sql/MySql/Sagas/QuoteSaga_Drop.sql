
/* TableNameVariable */

set @tableNameQuoted = concat('`', @tablePrefix, 'QuoteSaga`');
set @tableNameNonQuoted = concat(@tablePrefix, 'QuoteSaga');


/* DropTable */

set @dropTable = concat('drop table if exists ', @tableNameQuoted);
prepare script from @dropTable;
execute script;
deallocate prepare script;
