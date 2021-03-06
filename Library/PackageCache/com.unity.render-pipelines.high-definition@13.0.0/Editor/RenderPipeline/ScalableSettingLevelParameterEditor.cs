using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

namespace UnityEditor.Rendering.HighDefinition
{
    [VolumeParameterDrawer(typeof(ScalableSettingLevelParameter))]
    sealed class ScalableSettingLevelParameterEditor : VolumeParameterDrawer
    {
        public override bool OnGUI(SerializedDataParameter parameter, GUIContent title)
        {
            var value = parameter.value;

            if (value.propertyType != SerializedPropertyType.Integer)
                return false;

            var o = parameter.GetObjectRef<ScalableSettingLevelParameter>();
            var (level, useOverride) = o.levelAndOverride;

            var rect = EditorGUILayout.GetControlRect();

            var levelAndOverride = SerializedScalableSettingValueUI.LevelFieldGUI(
                rect,
                title,
                ScalableSettingSchema.GetSchemaOrNull(ScalableSettingSchemaId.With3Levels),
                level,
                useOverride
            );
            value.intValue = ScalableSettingLevelParameter.GetScalableSettingLevelParameterValue(levelAndOverride.level, levelAndOverride.useOverride);
            return true;
        }
    }
}
