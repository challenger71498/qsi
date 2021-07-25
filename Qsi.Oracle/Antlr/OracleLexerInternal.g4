lexer grammar OracleLexerInternal;

channels { ERRORCHANNEL }

DOT_SYMBOL:                 '.';
COMMA_SYMBOL:               ',';
SEMICOLON_SYMBOL:           ';';
EQUAL_OPERATOR:             '=';
NOT_EQUAL_OPERATOR:         '!=';
NOT_EQUAL2_OPERATOR:        '<>';
LESS_THEN_EQUAL_OPERATOR:   '<=';
GREATER_THEN_EQUAL_OPERATOR:'>=';
LESS_THEN_OPERATOR:         '<';
GREATER_THEN_OPERATOR:      '>';
BITWISE_XOR_OPERATOR:       '^';
BIT_XOR_OPERATOR:           '^=';
PLUS_OPERATOR:              '+';
MINUS_OPERATOR:             '-';
MULT_OPERATOR:              '*';
DIV_OPERATOR:               '/';
HINT_OPEN_OPERATOR:         '/*+';
HINT_CLOSE_OPERATOR:        '*/';
HINT_OPEN2_OPERATOR:        '--+';
CONCAT_OPERATOR:            '||';
LEFT_BRACKET:               '[';
LEFT_CURLY_BRACKET:         '{';
OPEN_PAR_SYMBOL:            '(';
RIGHT_BRACKET:              ']';
RIGHT_CURLY_BRACKET:        '}';
CLOSE_PAR_SYMBOL:           ')';
AT_SIGN_BRACKET:            '@';
PIPE_SIGN:                  '|';
DOLLAR_SIGN:                '$';
QMARK:                      '?';
LEFT_CURLY_BRACKET2:        '{-';
RIGHT_CURLY_BRACKET2:       '-}';
COLON:                      ':';
S_SINGLE_QUOTE: SINGLE_QUOTE;

fragment A: [aA];
fragment B: [bB];
fragment C: [cC];
fragment D: [dD];
fragment E: [eE];
fragment F: [fF];
fragment G: [gG];
fragment H: [hH];
fragment I: [iI];
fragment J: [jJ];
fragment K: [kK];
fragment L: [lL];
fragment M: [mM];
fragment N: [nN];
fragment O: [oO];
fragment P: [pP];
fragment Q: [qQ];
fragment R: [rR];
fragment S: [sS];
fragment T: [tT];
fragment U: [uU];
fragment V: [vV];
fragment W: [wW];
fragment X: [xX];
fragment Y: [yY];
fragment Z: [zZ];
fragment DIGIT: [0-9];
fragment SINGLE_QUOTE: '\'';
fragment DOUBLE_QUOTE: '"';
fragment ALPHABET: [A-Za-z];

ADD: A D D;
AFTER: A F T E R;
AGGREGATE: A G G R E G A T E;
ALL: A L L;
ALL_ROWS: A L L '_' R O W S;
CLUSTER: C L U S T E R;
CLUSTERING: C L U S T E R I N G;
INDEX_ASC: I N D E X '_' A S C;
APPEND: A P P E N D;
DYNAMIC_SAMPLING: D Y N A M I C '_' S A M P L I N G;
CURSOR_SHARING_EXACT: C U R S O R '_' S H A R I N G '_' E X A C T;
APPEND_VALUES: A P P E N D '_' V A L U E S;
DRIVING_SITE: D R I V I N G '_' S I T E;
ENABLE_PARALLEL_DML: E N A B L E '_' P A R A L L E L '_' D M L;
DISABLE_PARALLEL_DML: D I S A B L E '_' P A R A L L E L '_' D M L;
CHANGE_DUPKEY_ERROR_INDEX: C H A N G E '_' D U P K E Y '_' E R R O R '_' I N D E X;
DEFAULT_PDB_HINT: D E F A U L T '_' P D B '_' H I N T;
ALTERNATE: A L T E R N A T E;
ANALYTIC: A N A L Y T I C;
AND: A N D;
ANY: A N Y;
APPLY: A P P L Y;
AS: A S;
ASC: A S C;
AT: A T;
ATTRIBUTE: A T T R I B U T E;
ATTRIBUTES: A T T R I B U T E S;
AUTOMATIC: A U T O M A T I C;
BETWEEN: B E T W E E N;
BLOCK: B L O C K;
BREADTH: B R E A D T H;
BY: B Y;
CACHE: C A C H E;
CAPTION: C A P T I O N;
CASE: C A S E;
CHECK: C H E C K;
CLASSIFICATION: C L A S S I F I C A T I O N;
CLASSIFIER: C L A S S I F I E R;
CODE: C O D E;
COLLATE: C O L L A T E;
COLUMNS: C O L U M N S;
INDEX_COMBINE: I N D E X '_' C O M B I N E;
INDEX_DESC: I N D E X '_' D E S C;
INDEX_FFS: I N D E X '_' F F S;
INDEX_JOIN: I N D E X '_' J O I N;
INDEX_SS: I N D E X '_' S S;
INDEX_SS_ASC: I N D E X '_' S S '_' A S C;
INDEX_SS_DESC: I N D E X '_' S S '_' D E S C;
CONNECT: C O N N E C T;
INDEX: I N D E X;
INMEMORY: I N M E M O R Y;
MERGE: M E R G E;
INMEMORY_PRUNING: I N M E M O R Y '_' P R U N I N G;
CONSTRAINT: C O N S T R A I N T;
CONTAINERS: C O N T A I N E R S;
CREATE: C R E A T E;
CROSS: C R O S S;
CUBE: C U B E;
NO_EXPAND: N O '_' E X P A N D;
NO_PQ_CONCURRENT_UNION: N O '_' P Q '_' C O N C U R R E N T '_' U N I O N;
NO_FACT: N O '_' F A C T;
NOCACHE: N O C A C H E;
NO_PARALLEL_INDEX: N O '_' P A R A L L E L '_' I N D E X;
NO_PUSH_PRED: N O '_' P U S H '_' P R E D;
NO_PQ_SKEW: N O '_' P Q '_' S K E W;
NO_PARALLEL: N O '_' P A R A L L E L;
NO_MONITOR: N O '_' M O N I T O R;
CURRVAL: C U R R V A L;
NO_INDEX: N O '_' I N D E X;
NO_INDEX_SS: N O '_' I N D E X '_' S S;
NO_MERGE: N O '_' M E R G E;
NO_INMEMORY_PRUNING: N O '_' I N M E M O R Y '_' P R U N I N G;
NO_PX_JOIN_FILTER: N O '_' P X '_' J O I N '_' F I L T E R;
NO_QUERY_TRANSFORMATION: N O '_' Q U E R Y '_' T R A N S F O R M A T I O N;
CURSOR: C U R S O R;
NO_RESULT_CACHE: N O '_' R E S U L T '_' C A C H E;
NO_GATHER_OPTIMIZER_STATISTICS: N O '_' G A T H E R '_' O P T I M I Z E R '_' S T A T I S T I C S;
NO_INMEMORY: N O '_' I N M E M O R Y;
NO_INDEX_FFS: N O '_' I N D E X '_' F F S;
NO_CLUSTERING: N O '_' C L U S T E R I N G;
NOAPPEND: N O A P P E N D;
NATIVE_FULL_OUTER_JOIN: N A T I V E '_' F U L L '_' O U T E R '_' J O I N;
MODEL_MIN_ANALYSIS: M O D E L '_' M I N '_' A N A L Y S I S;
CYCLE: C Y C L E;
NO_NATIVE_FULL_OUTER_JOIN: N O '_' N A T I V E '_' F U L L '_' O U T E R '_' J O I N;
DATA: D A T A;
DAY: D A Y;
MONITOR: M O N I T O R;
DAYS: D A Y S;
LEADING: L E A D I N G;
DBTIMEZONE: D B T I M E Z O N E;
DECREMENT: D E C R E M E N T;
DEFAULT: D E F A U L T;
DEFINE: D E F I N E;
DELETE: D E L E T E;
DEPTH: D E P T H;
DESC: D E S C;
DESCRIPTION: D E S C R I P T I O N;
DETERMINES: D E T E R M I N E S;
DIMENSION: D I M E N S I O N;
DISTINCT: D I S T I N C T;
ELSE: E L S E;
ENABLE: E N A B L E;
END: E N D;
ERRORS: E R R O R S;
EXCLUDE: E X C L U D E;
FACT: F A C T;
FETCH: F E T C H;
NO_STATEMENT_QUEUING: N O '_' S T A T E M E N T '_' Q U E U I N G;
FILTER: F I L T E R;
FINAL: F I N A L;
NO_ZONEMAP: N O '_' Z O N E M A P;
SCAN: S C A N;
ORDERED: O R D E R E D;
OPT_PARAM: O P T '_' P A R A M;
PARALLEL_INDEX: P A R A L L E L '_' I N D E X;
NO_XMLINDEX_REWRITE: N O '_' X M L I N D E X '_' R E W R I T E;
NO_XML_QUERY_REWRITE: N O '_' X M L '_' Q U E R Y '_' R E W R I T E;
NO_REWRITE: N O '_' R E W R I T E;
NO_USE_BAND: N O '_' U S E '_' B A N D;
NO_USE_CUBE: N O '_' U S E '_' C U B E;
NO_USE_HASH: N O '_' U S E '_' H A S H;
NO_USE_MERGE: N O '_' U S E '_' M E R G E;
FIRST: F I R S T;
NO_STAR_TRANSFORMATION: N O '_' S T A R '_' T R A N S F O R M A T I O N;
FOR: F O R;
FORCE: F O R C E;
FROM: F R O M;
FULL: F U L L;
NO_USE_NL: N O '_' U S E '_' N L;
HASH: H A S H;
IGNORE_ROW_ON_DUPKEY_INDEX: I G N O R E '_' R O W '_' O N '_' D U P K E Y '_' I N D E X;
FIRST_ROWS: F I R S T '_' R O W S;
FRESH_MV: F R E S H '_' M V;
GROUP: G R O U P;
GROUPING: G R O U P I N G;
HALF_YEARS: H A L F '_' Y E A R S;
HAVING: H A V I N G;
GATHER_OPTIMIZER_STATISTICS: G A T H E R '_' O P T I M I Z E R '_' S T A T I S T I C S;
HIERARCHIES: H I E R A R C H I E S;
HOURS: H O U R S;
IGNORE: I G N O R E;
IN: I N;
INCLUDE: I N C L U D E;
INCREMENT: I N C R E M E N T;
INNER: I N N E R;
INTERSECT: I N T E R S E C T;
INTO: I N T O;
ITERATE: I T E R A T E;
JOIN: J O I N;
KEEP: K E E P;
KEY: K E Y;
LANGUAGE: L A N G U A G E;
LAST: L A S T;
LATERAL: L A T E R A L;
LEFT: L E F T;
LEVEL: L E V E L;
LEVELS: L E V E L S;
LIKE: L I K E;
LIMIT: L I M I T;
LOCAL: L O C A L;
LOCKED: L O C K E D;
LOG: L O G;
MAIN: M A I N;
MATCH: M A T C H;
MATCH_NUMBER: M A T C H '_' N U M B E R;
MATCH_RECOGNIZE: M A T C H '_' R E C O G N I Z E;
MATERIALIZED: M A T E R I A L I Z E D;
MAX: M A X;
MAXVALUE: M A X V A L U E;
MEASURE: M E A S U R E;
MEASURES: M E A S U R E S;
MEMBER: M E M B E R;
METADATA: M E T A D A T A;
MIN: M I N;
MINUS: M I N U S;
MINUTES: M I N U T E S;
MINVALUE: M I N V A L U E;
MODEL: M O D E L;
MONTH: M O N T H;
MONTHS: M O N T H S;
NAME: N A M E;
NATURAL: N A T U R A L;
NAV: N A V;
NEXT: N E X T;
NEXTVAL: N E X T V A L;
NOCYCLE: N O C Y C L E;
NOFORCE: N O F O R C E;
NONE: N O N E;
NORELY: N O R E L Y;
NOT: N O T;
NOWAIT: N O W A I T;
NULL: N U L L;
NULLS: N U L L S;
OF: O F;
OFFSET: O F F S E T;
ON: O N;
NO_PUSH_SUBQ: N O '_' P U S H '_' S U B Q;
NO_UNNEST: N O '_' U N N E S T;
QB_NAME: Q B '_' N A M E;
ONE: O N E;
ONLY: O N L Y;
OPTION: O P T I O N;
OR: O R;
ORDER: O R D E R;
OUTER: O U T E R;
PARTITION: P A R T I T I O N;
PAST: P A S T;
PATH: P A T H;
PATTERN: P A T T E R N;
PER: P E R;
PERCENT: P E R C E N T;
PERIOD: P E R I O D;
PERMUTE: P E R M U T E;
PIVOT: P I V O T;
PREV: P R E V;
PRIOR: P R I O R;
QUARTERS: Q U A R T E R S;
QUERY: Q U E R Y;
READ: R E A D;
REFERENCE: R E F E R E N C E;
REFERENCES: R E F E R E N C E S;
REJECT: R E J E C T;
RELY: R E L Y;
REMOTE: R E M O T E;
REPLACE: R E P L A C E;
RETURN: R E T U R N;
RETURNING: R E T U R N I N G;
RIGHT: R I G H T;
ROLLBACK: R O L L B A C K;
ROLLUP: R O L L U P;
ROW: R O W;
ROWID: R O W I D;
ROWNUM: R O W N U M;
ROWS: R O W S;
RULES: R U L E S;
RUNNING: R U N N I N G;
SAMPLE: S A M P L E;
SAVEPOINT: S A V E P O I N T;
SCN: S C N;
SEARCH: S E A R C H;
SECOND: S E C O N D;
SECONDS: S E C O N D S;
SEED: S E E D;
SELECT: S E L E C T;
SEQUENTIAL: S E Q U E N T I A L;
SESSIONTIMEZONE: S E S S I O N T I M E Z O N E;
SET: S E T;
SETS: S E T S;
SHARDS: S H A R D S;
SHARING: S H A R I N G;
SIBLINGS: S I B L I N G S;
SINGLE: S I N G L E;
K_SKIP: S K I P;
STANDARD: S T A N D A R D;
START: S T A R T;
SUBPARTITION: S U B P A R T I T I O N;
SUBSET: S U B S E T;
TABLE: T A B L E;
THEN: T H E N;
TIES: T I E S;
TIME: T I M E;
TIMESTAMP: T I M E S T A M P;
TO: T O;
TRANSFORM: T R A N S F O R M;
TYPE: T Y P E;
UNION: U N I O N;
UNIQUE: U N I Q U E;
UNLIMITED: U N L I M I T E D;
UNPIVOT: U N P I V O T;
UNTIL: U N T I L;
UPDATE: U P D A T E;
UPDATED: U P D A T E D;
UPSERT: U P S E R T;
USING: U S I N G;
VALUE: V A L U E;
VERSIONS: V E R S I O N S;
VIEW: V I E W;
WAIT: W A I T;
WEEKS: W E E K S;
WHEN: W H E N;
WHERE: W H E R E;
WINDOW: W I N D O W;
WITH: W I T H;
WORK: W O R K;
XML: X M L;
YEAR: Y E A R;
YEARS: Y E A R S;
ZONE: Z O N E;
PQ_CONCURRENT_UNION: P Q '_' C O N C U R R E N T '_' U N I O N;
PQ_FILTER: P Q '_' F I L T E R;
RANDOM: R A N D O M;
SERIAL: S E R I A L;
PQ_SKEW: P Q '_' S K E W;
PUSH_PRED: P U S H '_' P R E D;
PUSH_SUBQ: P U S H '_' S U B Q;
PX_JOIN_FILTER: P X '_' J O I N '_' F I L T E R;
FALSE: F A L S E;
RESULT_CACHE: R E S U L T '_' C A C H E;
TEMP: T E M P;
TRUE: T R U E;
RETRY_ON_ROW_CHANGE: R E T R Y '_' O N '_' R O W '_' C H A N G E;
REWRITE: R E W R I T E;
STAR_TRANSFORMATION: S T A R '_' T R A N S F O R M A T I O N;
STATEMENT_QUEUING: S T A T E M E N T '_' Q U E U I N G;
UNNEST: U N N E S T;
USE_BAND: U S E '_' B A N D;
USE_CONCAT: U S E '_' C O N C A T;
USE_CUBE: U S E '_' C U B E;
USE_HASH: U S E '_' H A S H;
USE_MERGE: U S E '_' M E R G E;
USE_NL: U S E '_' N L;
USE_NL_WITH_INDEX: U S E '_' N L '_' W I T H '_' I N D E X;
RANGE: R A N G E;
UNBOUNDED: U N B O U N D E D;
PRECEDING: P R E C E D I N G;
CURRENT: C U R R E N T;
FOLLOWING: F O L L O W I N G;
DATE: D A T E;
INTERVAL: I N T E R V A L;

UNQUOTED_OBJECT_NAME: ALPHABET [A-Za-z0-9_$#]*;
QUOTED_OBJECT_NAME: DOUBLE_QUOTE ~[\r\n"]* DOUBLE_QUOTE;

S_INTEGER_WITH_SIGN: ('+'|'-') S_INTEGER_WITHOUT_SIGN;
S_NUMBER_WITH_SIGN: ('+'|'-') S_NUMBER_WITHOUT_SIGN;
S_INTEGER_WITHOUT_SIGN: DIGIT+;
S_NUMBER_WITHOUT_SIGN: (DIGIT+ '.'? DIGIT* | '.' DIGIT+) (E? ('+' | '-')? DIGIT+)? (F|D)?;

SINGLE_QUOTED_STRING: '\'' ( '\'\'' | ~['] )* '\'';

QUOTED_STRING
    : Q '\'' ~[\u0000]* '\''
    ;

NATIONAL_STRING
    : N (
          SINGLE_QUOTED_STRING
        | QUOTED_STRING
    );

WHITESPACE:    [ \t\f\r\n] -> channel(HIDDEN); // Ignore whitespaces.
BLOCK_COMMENT: ( '/**/' | '/*' ~[+] .*? '*/') -> channel(HIDDEN);
COMMENT:       '--' ~[\r\n]* ('\r'? '\n' | EOF) -> channel(HIDDEN);