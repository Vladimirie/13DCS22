<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

class Cars extends Model
{
    protected $fillable = [
        "category_id",
        "name",
        "description",
        "color",
        "avaliable",
        "price"
    ];

    protected $casts = [
        "avaliable" => "boolean"
    ];

    public function category() : BelongsTo {
        return $this->belongsTo(category::class);
    }
}
