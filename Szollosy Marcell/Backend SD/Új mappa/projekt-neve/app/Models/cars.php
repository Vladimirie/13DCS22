<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

class cars extends Model
{
    protected $fillable = [
        'id',
        'category_id',
        'name',
        'description',
        'color',
        'available',
        'price'
    ];

    protected $casts = [

    ];
}
