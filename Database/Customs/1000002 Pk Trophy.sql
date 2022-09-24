DELETE FROM `weenie` WHERE `class_Id` = 1000002;

INSERT INTO `weenie` (`class_Id`, `class_Name`, `type`, `last_Modified`)
VALUES (1000002, 'ace1000002-pktrophy', 51, '2021-03-12 02:13:37') /* Stackable */;

INSERT INTO `weenie_properties_int` (`object_Id`, `type`, `value`)
VALUES (1000002,   1,        128) /* ItemType - Misc */
     , (1000002,   5,          5) /* EncumbranceVal */
     , (1000002,  11,        100) /* MaxStackSize */
     , (1000002,  12,          1) /* StackSize */
     , (1000002,  15,         25) /* StackUnitValue */
     , (1000002,  16,          1) /* ItemUseable - No */
     , (1000002,  19,         25) /* Value */
     , (1000002,  53,        101) /* PlacementPosition - Resting */
     , (1000002,  93,       1044) /* PhysicsState - Ethereal, IgnoreCollisions, Gravity */;

INSERT INTO `weenie_properties_bool` (`object_Id`, `type`, `value`)
VALUES (1000002,  11, True ) /* IgnoreCollisions */
     , (1000002,  13, True ) /* Ethereal */
     , (1000002,  14, True ) /* GravityStatus */
     , (1000002,  19, True ) /* Attackable */;

INSERT INTO `weenie_properties_string` (`object_Id`, `type`, `value`)
VALUES (1000002,   1, 'Pk Trophy') /* Name */
     , (1000002,  16, 'Bloody piece off a players corpse.') /* LongDesc */
     , (1000002,  20, 'Pk Trophies') /* PluralName */;

INSERT INTO `weenie_properties_d_i_d` (`object_Id`, `type`, `value`)
VALUES (1000002,   1,   33554817) /* Setup */
     , (1000002,   3,  536870932) /* SoundTable */
     , (1000002,   8,  100686488) /* Icon */
     , (1000002,  22,  872415275) /* PhysicsEffectTable */;

/* Lifestoned Changelog:
{
  "Changelog": [
    {
      "created": "2021-03-12T02:11:47.4293656Z",
      "author": "ACE.Adapter",
      "comment": "Weenie exported from ACEmulator world database using ACE.Adapter"
    }
  ],
  "IsDone": false
}
*/
