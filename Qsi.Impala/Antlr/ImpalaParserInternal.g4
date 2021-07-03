parser grammar ImpalaParserInternal;

options { 
    superClass = ImpalaBaseParser;
    tokenVocab = ImpalaLexerInternal;
}

@header {
    using Qsi.Data;
    using Qsi.Tree;
    using Qsi.Utilities;
}

root
    : lex+
    ;

lex
    : IDENT
    | EMPTY_IDENT
    | INTEGER_LITERAL
    | DECIMAL_LITERAL
    | STRING_LITERAL
    | DOTDOTDOT
    | COLON
    | SEMICOLON
    | COMMA
    | DOT
    | STAR
    | LPAREN
    | RPAREN
    | LBRACKET
    | RBRACKET
    | DIVIDE
    | MOD
    | ADD
    | SUBTRACT
    | BITAND
    | BITOR
    | BITXOR
    | BITNOT
    | EQUAL
    | NOT
    | LESSTHAN
    | GREATERTHAN
    | UNMATCHED_STRING_LITERAL
    | NOTEQUAL
    | UNEXPECTED_CHAR
    | UNUSED_RESERVED_WORD
    | KW_AND
    | KW_ADD
    | KW_AGGREGATE
    | KW_ALL
    | KW_ALTER
    | KW_ANALYTIC
    | KW_ANTI
    | KW_API_VERSION
    | KW_ARRAY
    | KW_AS
    | KW_ASC
    | KW_AUTHORIZATION
    | KW_AVRO
    | KW_BETWEEN
    | KW_BIGINT
    | KW_BINARY
    | KW_BLOCKSIZE
    | KW_BOOLEAN
    | KW_BY
    | KW_CACHED
    | KW_CASCADE
    | KW_CASE
    | KW_CAST
    | KW_CHANGE
    | KW_CHAR
    | KW_CLASS
    | KW_CLOSE_FN
    | KW_COLUMN
    | KW_COLUMNS
    | KW_COMMENT
    | KW_COMPRESSION
    | KW_COMPUTE
    | KW_CONSTRAINT
    | KW_COPY
    | KW_CREATE
    | KW_CROSS
    | KW_CUBE
    | KW_CURRENT
    | KW_DATA
    | KW_DATABASE
    | KW_DATABASES
    | KW_DATE
    | KW_DATETIME
    | KW_DECIMAL
    | KW_DEFAULT
    | KW_DELETE
    | KW_DELIMITED
    | KW_DESC
    | KW_DESCRIBE
    | KW_DISABLE
    | KW_DISTINCT
    | KW_DIV
    | KW_DOUBLE
    | KW_DROP
    | KW_ELSE
    | KW_ENABLE
    | KW_ENCODING
    | KW_END
    | KW_ESCAPED
    | KW_EXCEPT
    | KW_EXISTS
    | KW_EXPLAIN
    | KW_EXTENDED
    | KW_EXTERNAL
    | KW_FALSE
    | KW_FIELDS
    | KW_FILEFORMAT
    | KW_FILES
    | KW_FINALIZE_FN
    | KW_FIRST
    | KW_FLOAT
    | KW_FOLLOWING
    | KW_FOR
    | KW_FOREIGN
    | KW_FORMAT
    | KW_FORMATTED
    | KW_FROM
    | KW_FULL
    | KW_FUNCTION
    | KW_FUNCTIONS
    | KW_GRANT
    | KW_GROUP
    | KW_GROUPING
    | KW_HASH
    | KW_HAVING
    | KW_HUDIPARQUET
    | KW_ICEBERG
    | KW_IF
    | KW_IGNORE
    | KW_ILIKE
    | KW_IN
    | KW_INCREMENTAL
    | KW_INIT_FN
    | KW_INNER
    | KW_INPATH
    | KW_INSERT
    | KW_INT
    | KW_INTERMEDIATE
    | KW_INTERSECT
    | KW_INTERVAL
    | KW_INTO
    | KW_INVALIDATE
    | KW_IREGEXP
    | KW_IS
    | KW_JOIN
    | KW_KUDU
    | KW_LAST
    | KW_LEFT
    | KW_LEXICAL
    | KW_LIKE
    | KW_LIMIT
    | KW_LINES
    | KW_LOAD
    | KW_LOCATION
    | KW_MANAGED_LOCATION
    | KW_MAP
    | KW_MERGE_FN
    | KW_METADATA
    | KW_MINUS
    | KW_NORELY
    | KW_NOT
    | KW_NOVALIDATE
    | KW_NULL
    | KW_NULLS
    | KW_OFFSET
    | KW_ON
    | KW_OR
    | KW_LOGICAL_OR
    | KW_ORC
    | KW_ORDER
    | KW_OUTER
    | KW_OVER
    | KW_OVERWRITE
    | KW_PARQUET
    | KW_PARQUETFILE
    | KW_PARTITION
    | KW_PARTITIONED
    | KW_PARTITIONS
    | KW_PRECEDING
    | KW_PREPARE_FN
    | KW_PRIMARY
    | KW_PRODUCED
    | KW_PURGE
    | KW_RANGE
    | KW_RCFILE
    | KW_RECOVER
    | KW_REFERENCES
    | KW_REFRESH
    | KW_REGEXP
    | KW_RELY
    | KW_RENAME
    | KW_REPEATABLE
    | KW_REPLACE
    | KW_REPLICATION
    | KW_RESTRICT
    | KW_RETURNS
    | KW_REVOKE
    | KW_RIGHT
    | KW_RLIKE
    | KW_ROLE
    | KW_ROLES
    | KW_ROLLUP
    | KW_ROW
    | KW_ROWS
    | KW_SCHEMA
    | KW_SCHEMAS
    | KW_SELECT
    | KW_SEMI
    | KW_SEQUENCEFILE
    | KW_SERDEPROPERTIES
    | KW_SERIALIZE_FN
    | KW_SET
    | KW_SETS
    | KW_SHOW
    | KW_SMALLINT
    | KW_SORT
    | KW_SPEC
    | KW_STATS
    | KW_STORED
    | KW_STRAIGHT_JOIN
    | KW_STRING
    | KW_STRUCT
    | KW_SYMBOL
    | KW_TABLE
    | KW_TABLES
    | KW_TABLESAMPLE
    | KW_TBLPROPERTIES
    | KW_TERMINATED
    | KW_TEXTFILE
    | KW_THEN
    | KW_TIMESTAMP
    | KW_TINYINT
    | KW_TO
    | KW_TRUE
    | KW_TRUNCATE
    | KW_UNBOUNDED
    | KW_UNCACHED
    | KW_UNION
    | KW_UNKNOWN
    | KW_UNSET
    | KW_UPDATE
    | KW_UPDATE_FN
    | KW_UPSERT
    | KW_USE
    | KW_USING
    | KW_VALIDATE
    | KW_VALUES
    | KW_VARCHAR
    | KW_VIEW
    | KW_WHEN
    | KW_WHERE
    | KW_WITH
    | KW_ZORDER
    ;