<?php
global $lng;

$interface['name']    = 'Documents';
$interface['table']   = 'documents';
$interface['lng']     = $lng["main"]["documents"];

/* List Item */
$interface['actions']['list'] = array
(
    'usetemplate'      => 1,
    'useshelltemplate' => 1,
    'usebuffering'     => 1,
    'actiontitle'      => 'List',

    'params'           => array
    (
        'delete_check_box' => 1,
        'delete_link'      => 1,
        'sortby'           => "id",
    ),

    'fields'           => array
    (
        'id',
        'file_name',
        'file_size' => "doc_revisions.file_size",
        'title',
        'permission',
        'author' => "users.name",
        'created',
        'modified',
        'status',
        'head_revision',
    ),

    'details' => array
    (
        'created' => array
        (
            'type'      => 'date',
            'format'    => DT_SHORT_DATE_,
        ),
        'modified' => array
        (
            'type'      => 'date',
            'format'    => DT_SHORT_DATE_,
        ),
    ),
);

/* Edit */
$alng = $interface["lng"]["edit"];
$interface['actions']['edit'] = array
(
    'usetemplate'        => 1,
    'useshelltemplate'   => 1,
    'usebuffering'       => 1,
    'actiontitle'        => 'Edit',

    'fields' => array
    (
        'id',
        'category',
        'title',
        'expires',
        'never_expired',
        'send_expired_email',
        'ndownload',
        'description',
        'head_revision',
        'file_name',
        'permission',
        'author',
    ),

    'details' => array
    (
        'title' => array(
            'type'      => 'text',
            'control'   => 'text',
            'title'     => $alng["lbl_edit_title"],
            'required'  => 1,
        ),
        'expires'    => array
        (
            'type'           => 'date',
            'format'         => DT_SHORT_DATE_,
        ),
    ),
);

/* Delete Article */
$interface['actions']['delete'] = array
(
    'usetemplate'        => 0,
    'useshelltemplate'   => 0,
    'usebuffering'       => 1,
    'actiontitle'        => 'Delete',
    'redirect'           => 'list',
);

/* Delete Article (SubDocument) */
$interface['actions']['subdelete'] = array
(
    'usetemplate'        => 0,
    'useshelltemplate'   => 0,
    'usebuffering'       => 1,
    'actiontitle'        => 'Delete',
    'redirect'           => 'list',
);

/* Save Article */
$interface['actions']['save'] = array
(
    'usetemplate'        => 0,
    'useshelltemplate'   => 0,
    'usebuffering'       => 1,
    'actiontitle'        => 'Save',
    'redirect'           => 'list',

    'fields' => array
    (
        'category',
        'title',
        'expires',
        'never_expired',
        'send_expired_email',
        'ndownload',
        'description',
		'notify',
        'permission',
		'created',
		'modified',
		'author_id'
    ),

    'details' => array
    (
        'expires'    => array
        (
            'type'       => 'date',
            'format'     => DT_SHORT_DATE_,
        ),
        'created' => array
        (
            'type'      => 'date',
            'format'    => DT_SHORT_DATE_,
        ),
        'modified' => array
        (
            'type'      => 'date',
            'format'    => DT_SHORT_DATE_,
        ),
    ),
);

$interface['actions']['add_complete'] = array
(
    'usetemplate'        => 1,
    'useshelltemplate'   => 1,
    'usebuffering'       => 1,
    'actiontitle'        => 'Add Complete',
);

$interface['actions']['view'] = array
(
    'usetemplate'        => 1,
    'useshelltemplate'   => 1,
    'usebuffering'       => 1,
    'actiontitle'        => 'View Document',
);

$interface['actions']['view_group'] = array
(
    'usetemplate'        => 1,
    'useshelltemplate'   => 1,
    'usebuffering'       => 1,
    'actiontitle'        => 'View Group Document',
);

$interface['actions']['checkout'] = array
(
    'usetemplate'        => 1,
    'useshelltemplate'   => 1,
    'usebuffering'       => 1,
    'actiontitle'        => 'Check Out',
);

$interface['actions']['checkout_save'] = array
(
    'usetemplate'        => 0,
    'useshelltemplate'   => 0,
    'usebuffering'       => 1,
    'actiontitle'        => 'Checked Out...',
);

$interface['actions']['reset'] = array
(
    'usetemplate'        => 0,
    'useshelltemplate'   => 0,
    'usebuffering'       => 1,
    'actiontitle'        => 'Reset',
);

$interface['actions']['email'] = array
(
    'usetemplate'        => 1,
    'useshelltemplate'   => 1,
    'usebuffering'       => 1,
    'actiontitle'        => 'Email Users',
);

$interface['actions']['email_send'] = array
(
    'usetemplate'        => 0,
    'useshelltemplate'   => 0,
    'usebuffering'       => 1,
    'actiontitle'        => 'Sending...',
);

$interface['actions']['email_complete'] = array
(
    'usetemplate'        => 1,
    'useshelltemplate'   => 1,
    'usebuffering'       => 1,
    'actiontitle'        => 'Email Complete',
);

$interface['actions']['download'] = array
(
    'usetemplate'        => 0,
    'useshelltemplate'   => 0,
    'usebuffering'       => 1,
    'actiontitle'        => 'Download Users',
);

$interface['actions']['edit_category'] = array
(
    'usetemplate'        => 1,
    'useshelltemplate'   => 1,
    'usebuffering'       => 1,
    'actiontitle'        => 'Edit category',
);

$interface['actions']['delete_category'] = array
(
    'usetemplate'        => 0,
    'useshelltemplate'   => 0,
    'usebuffering'       => 1,
    'actiontitle'        => 'Delete',
    'redirect'           => 'list',
);

$interface['actions']['save_category'] = array
(
    'usetemplate'        => 0,
    'useshelltemplate'   => 0,
    'usebuffering'       => 1,
    'actiontitle'        => 'Save',
    'redirect'           => 'list',
);

$interface['actions']['stats'] = array
(
    'usetemplate'        => 1,
    'useshelltemplate'   => 1,
    'usebuffering'       => 1,
    'actiontitle'        => 'Stats',
);

$interface['actions']['report'] = array
(
    'usetemplate'      => 1,
    'useshelltemplate' => 1,
    'usebuffering'     => 1,
    'actiontitle'      => 'Report',
    'details' => array
    (
        'date_from'    => array
        (
            'type'       => 'date',
            'format'     => DT_SHORT_DATE_,
        ),
        'date_to' => array
        (
            'type'      => 'date',
            'format'    => DT_SHORT_DATE_,
        ),
    ),
);


#New addition by vikram singh
$interface['actions']['report1'] = array
(
    'usetemplate'      => 1,
    'useshelltemplate' => 1,
    'usebuffering'     => 1,
    'actiontitle'      => 'Report',
    'details' => array
    (
        'date_from'    => array
        (
            'type'       => 'date',
            'format'     => DT_SHORT_DATE_,
        ),
        'date_to' => array
        (
            'type'      => 'date',
            'format'    => DT_SHORT_DATE_,
        ),
    ),
);
?>
