CREATE OR REPLACE FUNCTION audit()
RETURNS TRIGGER AS $$
DECLARE
    old_jsonb jsonb := to_jsonb(OLD);
    new_jsonb jsonb := to_jsonb(NEW);
    old_deleted_by_id int4 = NULLIF(old_jsonb['deleted_by_id'], 'null')::int4;
    new_deleted_by_id int4 = NULLIF(new_jsonb['deleted_by_id'], 'null')::int4;
    executed_by_id int4 = COALESCE(NULLIF(new_jsonb['updated_by_id'], 'null')::int4, 1);
BEGIN
    CASE
        WHEN TG_OP = 'INSERT' THEN
        INSERT INTO system_action_histories(executed_by_id, "type", entity_name, occurred_at, "old", "new")
        VALUES (executed_by_id, 'create', TG_TABLE_NAME, now(), '{}', new_jsonb);
        RETURN NEW;

        WHEN TG_OP = 'UPDATE' AND old_deleted_by_id IS NULL AND new_deleted_by_id IS NOT NULL THEN
        INSERT INTO system_action_histories(executed_by_id, "type", entity_name, occurred_at, "old", "new")
        VALUES (executed_by_id, 'soft_delete', TG_TABLE_NAME, now(), old_jsonb, new_jsonb);
        RETURN NEW;

        WHEN TG_OP = 'UPDATE' THEN
        INSERT INTO system_action_histories(executed_by_id, "type", entity_name, occurred_at, "old", "new")
        VALUES (executed_by_id, 'update', TG_TABLE_NAME, now(), old_jsonb, new_jsonb);
        RETURN NEW;

        WHEN TG_OP = 'DELETE' THEN
        INSERT INTO system_action_histories(executed_by_id, "type", entity_name, occurred_at, "old", "new")
        VALUES (executed_by_id, 'hard_delete', TG_TABLE_NAME, now(), old_jsonb, '{}');
        RETURN OLD;
    END CASE;
END;
$$ LANGUAGE plpgsql;

CREATE OR REPLACE TRIGGER categories_audit_trigger
AFTER INSERT OR UPDATE OR DELETE ON categories
FOR EACH ROW EXECUTE FUNCTION audit();

CREATE OR REPLACE TRIGGER category_ingredient_audit_trigger
AFTER INSERT OR UPDATE OR DELETE ON category_ingredient
FOR EACH ROW EXECUTE FUNCTION audit();

CREATE OR REPLACE TRIGGER category_kitchenware_audit_trigger
AFTER INSERT OR UPDATE OR DELETE ON category_kitchenware
FOR EACH ROW EXECUTE FUNCTION audit();

CREATE OR REPLACE TRIGGER comments_audit_trigger
AFTER INSERT OR UPDATE OR DELETE ON "comments"
FOR EACH ROW EXECUTE FUNCTION audit();

CREATE OR REPLACE TRIGGER ingredient_recipe_audit_trigger
AFTER INSERT OR UPDATE OR DELETE ON ingredient_recipe
FOR EACH ROW EXECUTE FUNCTION audit();

CREATE OR REPLACE TRIGGER ingredients_audit_trigger
AFTER INSERT OR UPDATE OR DELETE ON ingredients
FOR EACH ROW EXECUTE FUNCTION audit();

CREATE OR REPLACE TRIGGER keyword_recipe_audit_trigger
AFTER INSERT OR UPDATE OR DELETE ON keyword_recipe
FOR EACH ROW EXECUTE FUNCTION audit();

CREATE OR REPLACE TRIGGER keyword_recipe_collection_audit_trigger
AFTER INSERT OR UPDATE OR DELETE ON keyword_recipe_collection
FOR EACH ROW EXECUTE FUNCTION audit();

CREATE OR REPLACE TRIGGER keywords_audit_trigger
AFTER INSERT OR UPDATE OR DELETE ON keywords
FOR EACH ROW EXECUTE FUNCTION audit();

CREATE OR REPLACE TRIGGER kitchenware_recipe_audit_trigger
AFTER INSERT OR UPDATE OR DELETE ON kitchenware_recipe
FOR EACH ROW EXECUTE FUNCTION audit();

CREATE OR REPLACE TRIGGER kitchenwares_audit_trigger
AFTER INSERT OR UPDATE OR DELETE ON kitchenwares
FOR EACH ROW EXECUTE FUNCTION audit();

CREATE OR REPLACE TRIGGER recipe_collections_audit_trigger
AFTER INSERT OR UPDATE OR DELETE ON recipe_collections
FOR EACH ROW EXECUTE FUNCTION audit();

CREATE OR REPLACE TRIGGER recipe_recipe_collection_audit_trigger
AFTER INSERT OR UPDATE OR DELETE ON recipe_recipe_collection
FOR EACH ROW EXECUTE FUNCTION audit();

CREATE OR REPLACE TRIGGER recipes_audit_trigger
AFTER INSERT OR UPDATE OR DELETE ON recipes
FOR EACH ROW EXECUTE FUNCTION audit();

CREATE OR REPLACE TRIGGER system_configs_audit_trigger
AFTER INSERT OR UPDATE OR DELETE ON system_configs
FOR EACH ROW EXECUTE FUNCTION audit();

CREATE OR REPLACE TRIGGER user_actions_audit_trigger
AFTER INSERT OR UPDATE OR DELETE ON user_actions
FOR EACH ROW EXECUTE FUNCTION audit();

CREATE OR REPLACE TRIGGER user_feedback_audit_trigger
AFTER INSERT OR UPDATE OR DELETE ON user_feedback
FOR EACH ROW EXECUTE FUNCTION audit();

CREATE OR REPLACE TRIGGER users_audit_trigger
AFTER INSERT OR UPDATE OR DELETE ON users
FOR EACH ROW EXECUTE FUNCTION audit();