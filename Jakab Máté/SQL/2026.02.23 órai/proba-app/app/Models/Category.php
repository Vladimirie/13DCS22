<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\HasMany;
class Category extends Model
{
    //
    protected $fillable = [
        'name',
        'is_active'
    ];

    protected $casts = [
        'is_active' => 'boolean' 
    ];

    public function menuItems(): HasMany{
        return $this->hasMany(MenuItems::class);
    }

}